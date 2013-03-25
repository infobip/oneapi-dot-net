using System.Net;
using RestSharp;

namespace OneApi.Model
{
    public class RequestData
    {
        public const string FORM_URL_ENCOEDED_CONTENT_TYPE = "application/x-www-form-urlencoded; charset=utf-8";
        public const string JSON_CONTENT_TYPE = "application/json; charset=utf-8";

        public HttpWebRequest Request { get; set; }
        public string ResourcePath { get; set; }
        public Method RequestMethod { get; set; }
        public string RootElement { get; set; }
        public object FormParams { get; set; }
        public string ContentType { get; set; }

        public RequestData(string resourcePath, Method requestMethod)
        {
            this.ResourcePath = resourcePath;
            this.RequestMethod = requestMethod;
            this.ContentType = FORM_URL_ENCOEDED_CONTENT_TYPE;
        }

        public RequestData(string apiUrl, Method requestMethod, object formParams)
            : this(apiUrl, requestMethod)
        {
            this.FormParams = formParams;
        }

        public RequestData(string resourcePath, Method requestMethod, string rootElement)
            : this(resourcePath, requestMethod)
        {
            this.RootElement = rootElement;
        }

        public RequestData(string resourcePath, Method requestMethod, string rootElement, object formParams)
            : this(resourcePath, requestMethod, rootElement)
        {
            this.FormParams = formParams;
        }
    }
}
