using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using OneApi.Config;
using OneApi.Exceptions;
using OneApi.Model;

namespace OneApi.Client.Impl
{
 		
    /// <summary>
	/// Client base class containing common methods and properties
	/// 
	/// </summary>
    public class OneAPIBaseClientImpl
    {
        protected static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected internal const int RESPONSE_CODE_200_OK = 200;

        protected internal const int RESPONSE_CODE_201_CREATED = 201;

        protected internal const int RESPONSE_CODE_204_NO_CONTENT = 204;

        private const string POST_REQUEST_METHOD = "POST";

        private const string PUT_REQUEST_METHOD = "PUT";

        private const string GET_REQUEST_METHOD = "GET";

        private const string DELETE_REQUEST_METHOD = "DELETE";

        private const string URL_ENCODED_CONTENT_TYPE = "application/x-www-form-urlencoded";

        private Configuration configuration = null;

        /// <summary>
        /// Initialize OneAPIClientBase </summary>
        /// <param name="configuration"> </param>
        protected internal OneAPIBaseClientImpl(Configuration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Get Configuration object </summary>
        /// <returns> Configuration </returns>
        protected internal Configuration Configuration
        {
            get
            {
                return configuration;
            }
        }

        /// <summary>
        /// Execute POST Request </summary>
        /// <param name="apiUrl"> </param>
        /// <returns> HttpWebResponse </returns>
        protected internal HttpWebResponse ExecutePost(string apiUrl)
        {
            return ExecutePost(apiUrl, null);
        }

        /// <summary>
        /// Execute POST Request </summary>
        /// <param name="apiUrl"> </param>
        /// <param name="formParams"> </param>
        /// <returns> HttpWebResponse </returns>
        protected internal HttpWebResponse ExecutePost(string apiUrl, object formParams)
        {
            return SendOneAPIRequest(POST_REQUEST_METHOD, apiUrl, formParams, URL_ENCODED_CONTENT_TYPE);
        }

        /// <summary>
        /// Execute PUT Request </summary>
        /// <param name="apiUrl"> </param>
        /// <param name="formParams"> </param>
        /// <returns> HttpWebResponse </returns>
        protected internal HttpWebResponse ExecutePut(string apiUrl, object formParams)
        {
            return SendOneAPIRequest(PUT_REQUEST_METHOD, apiUrl, formParams, URL_ENCODED_CONTENT_TYPE);
        }

        /// <summary>
        /// Execute GET Request </summary>
        /// <param name="apiUrl"> </param>
        /// <returns> HttpWebResponse </returns>
        protected internal HttpWebResponse ExecuteGet(string apiUrl)
        {
            return SendOneAPIRequest(GET_REQUEST_METHOD, apiUrl);
        }

        /// <summary>
        /// Execute DELETE Request </summary>
        /// <param name="apiUrl"> </param>
        /// <returns> HttpWebResponse </returns>
        protected internal HttpWebResponse ExecuteDelete(string apiUrl)
        {
            return SendOneAPIRequest(DELETE_REQUEST_METHOD, apiUrl);
        }

        /// <summary>
        /// Setup connection </summary>
        /// <param name="requestMethod"> </param>
        /// <param name="apiUrl"> </param>
        /// <returns> HttpWebResponse </returns>
        private HttpWebResponse SendOneAPIRequest(string requestMethod, string apiUrl)
        {
            return SendOneAPIRequest(requestMethod, apiUrl, null, null);
        }

        /// <summary>
        /// Setup connection </summary>
        /// <param name="requestMethod"> </param>
        /// <param name="apiUrl"> </param>
        /// <param name="formParams"> </param>
        /// <param name="contentType"> </param>
        /// <returns> HttpWebResponse </returns>
        /// <exception cref="RequestException"> </exception>
        private HttpWebResponse SendOneAPIRequest(string requestMethod, string apiUrl, object formParams, string contentType)
        {
            try
            {
                HttpWebRequest request = null;
                HttpWebResponse response = null;

                //setup connection with custom authorization
                if (configuration.Authentication.Type.Equals(OneApi.Model.Authentication.AuthType.BASIC))
                {
                    request = SetupRequestWithCustomAuthorization(apiUrl, "Basic", GetAuthorizationHeader(configuration.Authentication.Username, configuration.Authentication.Password));
                }
                else if (configuration.Authentication.Type.Equals(OneApi.Model.Authentication.AuthType.OAUTH))
                {
                    request = SetupRequestWithCustomAuthorization(apiUrl, "OAuth", configuration.Authentication.AccessToken);
                }
               
                //Set Content Type
                if ((contentType != null) && (contentType.Length > 0))
                {
                    request.ContentType = contentType;
                }

                request.Accept = "*/*";

                //Set Request Method
                request.Method = requestMethod;

                //Set Request Body
                if (formParams != null)
                {    
                    // Encode form params to byte array
                    byte[] formParamsByteArray = FormEncodeParams(formParams);
                    if (formParamsByteArray != null)
                    {
                        request.ContentLength = formParamsByteArray.Length;
                      
                        // Get the request stream.
                        Stream dataStream = request.GetRequestStream();
                        
                        // Write the data to the request stream.
                        dataStream.Write(formParamsByteArray, 0, formParamsByteArray.Length);
                        // Close the Stream object.
                        dataStream.Close();  
                    }
                }

                if (LOGGER.IsDebugEnabled)
                {
                    LOGGER.Debug("Getting response...");
                }
                // Get the response.
                response = (HttpWebResponse)request.GetResponse();
                return response;
            }
            catch (WebException e)
            {
                if (e.Response == null)
                {
                    throw new RequestException(e.Message);
                }

                return (HttpWebResponse)e.Response;  
            }   
        }

        private HttpWebRequest SetupRequestWithCustomAuthorization(string url, string authorizationScheme, string authHeaderValue)
        {
            if (LOGGER.IsDebugEnabled)
            {
                LOGGER.Debug("Initiating connection to URL: " + url);
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            if (authHeaderValue != null)
            {
                request.Headers.Add("Authorization", authorizationScheme + " " + authHeaderValue);
               
                if (LOGGER.IsDebugEnabled)
                {
                    LOGGER.Debug("Authorization type " + authorizationScheme + " using " + authHeaderValue);
                }
            }
            return request;
        }

        private string GetAuthorizationHeader(string username, string password)
        {
            string credentials = username + ":" + password;
            byte[] credentialsAsBytes = Encoding.UTF8.GetBytes(credentials);
            return System.Convert.ToBase64String(credentialsAsBytes).Trim();
        }

        private byte[] FormEncodeParams(object formParams)
        {
            Dictionary<string, object> formParamsDictionary = formParams.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToDictionary(prop => (prop.GetCustomAttributes(typeof(DisplayNameAttribute), false).First() as DisplayNameAttribute).DisplayName, prop => prop.GetValue(formParams, null));

            if (formParamsDictionary == null)
            {
                if (LOGGER.IsDebugEnabled)
                {
                    LOGGER.Debug("No request form parameters!");
                }
                return null;
            }

            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (KeyValuePair<string, object> entry in formParamsDictionary)
            {
                if (entry.Value != null)
                {
                    if (entry.Value is string[])
                    {
                        string[] arr = (string[]) entry.Value;
                        foreach (string arrItem in arr)
                        {
                            if (arrItem != null)
                            {
                                AppendEncodedParam(sb, entry.Key, arrItem, i++);
                            }
                        }
                    }
                    else
                    {
                        AppendEncodedParam(sb, entry.Key, entry.Value, i++);
                    }
                }
            }

            if (LOGGER.IsDebugEnabled)
            {
                LOGGER.Debug("Request form parameters: " + sb.ToString());
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        private void AppendEncodedParam(StringBuilder sb, string key, object value, int paramCounter)
        {
            if (paramCounter > 0)
            {
                sb.Append("&");
            }
            sb.Append(HttpUtility.UrlEncode(key));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode(Convert.ToString(value)));
        }

        /// <summary>
        /// Build url, append relativeScopeUrl to the messagingBaseUrl </summary>
        /// <param name="relativeApiUrl"> relative URL </param>
        /// <returns> String </returns>
        protected internal string AppendMessagingBaseUrl(string relativeApiUrl)
        {
            StringBuilder urlBuilder = new StringBuilder(configuration.ApiUrl);
            if (!configuration.ApiUrl.EndsWith("/"))
            {
                urlBuilder.Append("/");
            }
            urlBuilder.Append(configuration.VersionOneAPISMS);
            if (!relativeApiUrl.StartsWith("/"))
            {
                urlBuilder.Append("/");
            }

            urlBuilder.Append(relativeApiUrl);
            return urlBuilder.ToString();
        }

        protected internal T Deserialize<T>(HttpWebResponse response, int requiredStatus)
        {
            return Deserialize<T>(response, requiredStatus, null);
        }

        /// <summary>
        /// Deserialize response stream
        /// </summary>
        /// <param name="response"> </param>
        /// <param name="requiredStatus"> </param>
        /// <param name="rootElement"> </param>
        protected internal T Deserialize<T>(HttpWebResponse response, int requiredStatus, string rootElement)
        {     
            String json = String.Empty;
            
            if (((int)response.StatusCode) == (requiredStatus))
            {
                try
                {
                    return DeserializeStream<T>(response.GetResponseStream(), response.CharacterSet, rootElement);    
                }
                catch (Exception e)
                {
                    throw new RequestException(e);
                }
            }
            else
            {
                //Read RequestError from the response and throw the Exception
                throw ReadRequestException<RequestError>(response);
            }
        }

        /// <summary>
        /// Deserialize request stream
        /// </summary>
        /// <param name="request"> </param>
        /// <param name="rootElement"> </param>
        protected internal T Deserialize<T>(HttpWebRequest request, string rootElement)
        {
            return DeserializeStream<T>(request.GetRequestStream(), Encoding.UTF8.BodyName, rootElement);
        }

        /// <summary>
        /// Deserialize from stream
        /// </summary>
        /// <param name="request"> </param>
        /// <param name="rootElement"> </param>
        protected internal T DeserializeStream<T>(Stream stream, string characterSet, string rootElement)
        { 
            string json = String.Empty;
            
            Encoding encoding = Encoding.UTF8;
            if ((characterSet != null) && (characterSet.Trim() != ""))
            {
                encoding = Encoding.GetEncoding(characterSet);
            }
                   
            // read response
            using (StreamReader sr = new StreamReader(stream, encoding))
            {
                json = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }

            return ConvertJsonToObject<T>(json, rootElement);
        }

        protected internal T ConvertJsonToObject<T>(String json)
        {
            return ConvertJsonToObject<T>(json, null);
        }

        protected internal T ConvertJsonToObject<T>(String json, string rootElement) 
        {
            if (LOGGER.IsDebugEnabled)
            {
                LOGGER.Debug("JSON to Deserialize: " + json);
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;
            settings.DateParseHandling = DateParseHandling.DateTime;
            settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            settings.NullValueHandling = NullValueHandling.Ignore;

            try
            {
                if (null != rootElement)
                {
                    JObject rootObject = JObject.Parse(json);
                    JToken rootToken = rootObject.SelectToken(rootElement);

                    return JsonConvert.DeserializeObject<T>(rootToken.ToString(), settings);
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(json, settings);
                }
            }
            catch (Exception e)
            {
                throw new RequestException(e);
            }
        }

        private RequestException ReadRequestException<T>(HttpWebResponse response)
        {
            string errorText = "Unexpected error occured.";
            string messageId = "";
            string json = String.Empty;
            try
            {  
                RequestError requestError = DeserializeStream<RequestError>(response.GetResponseStream(), response.CharacterSet, "requestError");

                if (requestError != null)
                {
                    if (requestError.PolicyException != null)
                    {
                        errorText = requestError.PolicyException.Text;
                        messageId = requestError.PolicyException.MessageId;
                    }
                    else if (requestError.ServiceException != null)
                    {
                        errorText = requestError.ServiceException.Text;
                        messageId = requestError.ServiceException.MessageId;
                    }
                }
            }
            catch (Exception e)
            {
                return new RequestException(e, (int)response.StatusCode);
            }

            return new RequestException(errorText, messageId, (int)response.StatusCode);
        }

        protected internal void validateResponse(HttpWebResponse response, int requiredStatus)
        {
            if (((int)response.StatusCode) != (requiredStatus))
            {
                throw ReadRequestException<RequestError>(response);
            }
        }

        protected string GetIdFromResourceUrl(string resourceUrl) 
        {
            string id = "";
            if (resourceUrl.Contains('/'))
            {
                string[] arrResourceUrl = resourceUrl.Split('/');
                if (arrResourceUrl.Length > 0)
                {
                    id = arrResourceUrl[arrResourceUrl.GetUpperBound(0)];
                }
            }

            return id;
        }

    }
}