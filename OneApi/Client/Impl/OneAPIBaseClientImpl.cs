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
using System.Threading;
using RestSharp;
using OneApi.Converter;

namespace OneApi.Client.Impl
{
    /// <summary>
    /// Client base class containing common methods and properties
    /// 
    /// </summary>
    public class OneAPIBaseClientImpl
    {
        protected static log4net.ILog LOGGER = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Configuration configuration = null;
        private RestClient client = null;

        /// <summary>
        /// Initialize OneAPIClientBase </summary>
        /// <param name="configuration"> </param>
        protected OneAPIBaseClientImpl(Configuration configuration)
        {
            this.configuration = configuration;
            SetRestClient();
        }

        /// <summary>
        /// Get Configuration object </summary>
        /// <returns> Configuration </returns>
        protected Configuration Configuration
        {
            get
            {
                return configuration;
            }
        }

        /// <summary>
        /// Set Rest Client
        /// </summary>
        private void SetRestClient()
        {
            client = new RestClient(configuration.ApiUrl + "/" + configuration.VersionOneAPISMS);

            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = new AssemblyName(assembly.FullName);
            Version version = assemblyName.Version;

            client.UserAgent = "OneApi-C#-" + version;
        }

        /// <summary>
        /// Execute method and deserialize response json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestData"></param>
        /// <returns>T</returns>
        protected T ExecuteMethod<T>(RequestData requestData)
        {
            IRestResponse response = SendOneAPIRequest(requestData);
            var deserializedResponse = Deserialize<T>(response, requestData.RootElement);
            return deserializedResponse;
        }

        /// <summary>
        /// Execute method asynchronously and deserialize response json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestData"></param>
        /// <param name="callbackResponse"></param>
        /// 
        protected void ExecuteMethodAsync<T>(RequestData requestData, Action<T, RequestException> callbackResponse) where T : new()
        {
            SendOneAPIRequestAsync(requestData, callbackResponse);
        }

        /// <summary>
        /// Execute method and validate response 
        /// </summary>
        /// <param name="requestData"></param>
        protected void ExecuteMethod(RequestData requestData)
        {
            IRestResponse response = SendOneAPIRequest(requestData);
            ValidateResponse(response);
        }

        /// <summary>
        /// Send OneAPI request
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns> IRestResponse </returns>
        private IRestResponse SendOneAPIRequest(RequestData requestData)
        {
            RestRequest request = CreateRequest(requestData);
            return client.Execute(request);
        }

        /// <summary>
        /// Send OneAPI request asynchronously
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestData"></param>
        /// <param name="callbackResponse"></param>
        private void SendOneAPIRequestAsync<T>(RequestData requestData, Action<T, RequestException> callbackResponse) where T : new()
        {
            RestRequest request = CreateRequest(requestData);

            client.ExecuteAsync(request, (response) =>
            {
                try
                {
                    T jsonObject = Deserialize<T>(response, requestData.RootElement);
                    callbackResponse(jsonObject, null);
                }
                catch (RequestException e)
                {
                    callbackResponse(new T(), e);
                }
            });
        }

        /// <summary>
        /// Add Request parameters 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="formParams"></param>
        protected void AddRequestParams(ref RestRequest request, object formParams)
        {  
            Dictionary<string, object> formParamsDictionary = formParams.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToDictionary(prop => (prop.GetCustomAttributes(typeof(DisplayNameAttribute), false).First() as DisplayNameAttribute).DisplayName, prop => prop.GetValue(formParams, null));

            if (formParamsDictionary == null)
            {
                if (LOGGER.IsDebugEnabled)
                {
                    LOGGER.Debug("No request form parameters!");
                }
                return;
            }

            foreach (KeyValuePair<string, object> entry in formParamsDictionary)
            {
                if (entry.Value != null)
                {
                    if (entry.Value is string[])
                    {
                        string[] arr = (string[])entry.Value;
                        foreach (string arrItem in arr)
                        {
                            if (arrItem != null)
                            {
                                request.AddParameter(entry.Key, arrItem, ParameterType.GetOrPost);
                            }
                        }
                    }
                    else
                    {
                        request.AddParameter(entry.Key, Convert.ToString(entry.Value), ParameterType.GetOrPost);
                    }
                }
            }

            if (LOGGER.IsDebugEnabled)
            {
                LOGGER.Debug("Request form parameters: " + string.Join(", ", request.Parameters.ToArray().Select<Parameter, string>(ism => ism != null ? ism.ToString() : "{}").ToArray()));
            }
        }

        private RestRequest CreateRequest(RequestData requestData)
        {
            if (LOGGER.IsDebugEnabled)
            {
                LOGGER.Debug("Initiating connection to resource path: " + requestData.ResourcePath);
            }

            RestRequest request = new RestRequest(requestData.ResourcePath);

            //setup connection with custom authorization
            Authentication authentication = configuration.Authentication;
            if (authentication.Type.Equals(OneApi.Model.Authentication.AuthType.BASIC))
            {
                request = SetupRequestWithCustomAuthorization(ref request, "Basic", GetAuthorizationHeader(authentication.Username, authentication.Password));
            }
            else if (authentication.Type.Equals(OneApi.Model.Authentication.AuthType.IBSSO))
            {
                request = SetupRequestWithCustomAuthorization(ref request, "IBSSO", authentication.IbssoToken);
            }
            else if (authentication.Type.Equals(OneApi.Model.Authentication.AuthType.OAUTH))
            {
                request = SetupRequestWithCustomAuthorization(ref request, "OAuth", authentication.AccessToken);
            }

            request.AddHeader("Accept", "*/*");
            request.Method = requestData.RequestMethod;

            if (requestData.RequestMethod == Method.POST)
            {
                request.AddHeader("content-type", requestData.ContentType);

                if (requestData.FormParams != null)
                {
                    if (requestData.ContentType.Equals(RequestData.JSON_CONTENT_TYPE))
                    {
                        request.JsonSerializer = new RestSharpJsonNetSerializer();
                        request.RequestFormat = DataFormat.Json;
                        request.AddBody(requestData.FormParams);
                    }
                    else if (requestData.ContentType.Equals(RequestData.FORM_URL_ENCOEDED_CONTENT_TYPE))
                    {
                        AddRequestParams(ref request, requestData.FormParams);
                    }
                }
            }

            return request;
        }

        private RestRequest SetupRequestWithCustomAuthorization(ref RestRequest request, string authorizationScheme, string authHeaderValue)
        {
            if (authHeaderValue != null)
            {
                request.AddHeader("Authorization", authorizationScheme + " " + authHeaderValue);

                if (LOGGER.IsDebugEnabled)
                {
                    LOGGER.Debug("Authorization type " + authorizationScheme + " using " + authHeaderValue);
                }
            }

            return request;
        }

        /// <summary>
        /// Deserialize response stream
        /// </summary>
        /// <param name="response"> </param>
        /// <param name="rootElement"> </param>
        protected T Deserialize<T>(IRestResponse response, string rootElement)
        {
            int responseCode = (int)response.StatusCode;

            if (LOGGER.IsDebugEnabled)
            {
                LOGGER.Debug("Response status code: " + responseCode);
            }

            if (responseCode >= 200 && responseCode < 300)
            {	
                try
                {
                    return DeserializeStream<T>(response.Content, rootElement);
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
        /// Deserialize from stream
        /// </summary>
        /// <param name="request"> </param>
        /// <param name="rootElement"> </param>
        protected T DeserializeStream<T>(String content, string rootElement)
        {
            return ConvertJsonToObject<T>(content, rootElement);
        }

        /// <summary>
        /// Convert object to specific object type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        protected T ConvertJsonToObject<T>(String json)
        {
            return ConvertJsonToObject<T>(json, null);
        }

        /// <summary>
        /// Convert JSON to specific object type using json root element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="rootElement"></param>
        /// <returns></returns>
        public static T ConvertJsonToObject<T>(String json, string rootElement)
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

        private RequestException ReadRequestException<T>(IRestResponse response)
        {
            string errorText = "Unexpected error occured.";
            string messageId = "";
            string json = String.Empty;
            try
            {
                RequestError requestError = DeserializeStream<RequestError>(response.Content, "requestError");

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

        protected void ValidateResponse(IRestResponse response)
        {
            int responseCode = (int)response.StatusCode;

            if (LOGGER.IsDebugEnabled)
            {
                LOGGER.Debug("Response status code: " + responseCode);
            }

            if (!(responseCode >= 200 && responseCode < 300))
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

        private string GetAuthorizationHeader(string username, string password)
        {
            string credentials = username + ":" + password;
            byte[] credentialsAsBytes = Encoding.UTF8.GetBytes(credentials);
            return System.Convert.ToBase64String(credentialsAsBytes).Trim();
        }
    }
}