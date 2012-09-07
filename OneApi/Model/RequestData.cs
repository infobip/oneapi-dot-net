using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.Reflection;
using System.ComponentModel;
using RestSharp;

namespace OneApi.Model
{
    public class RequestData
    {
        public RequestData(string resourcePath, int requiredStatus, Method requestMethod)
        {
            ResourcePath = resourcePath;
            RequiredStatus = requiredStatus;
            RequestMethod = requestMethod;
        }

        public RequestData(string apiUrl, int requiredStatus, Method requestMethod, object formParams)
            : this(apiUrl, requiredStatus, requestMethod)
        {
            this.FormParams = formParams;
        }

        public RequestData(string resourcePath, int requiredStatus, Method requestMethod, string rootElement)
            : this(resourcePath, requiredStatus, requestMethod)
        {
            RootElement = rootElement;
        }

        public RequestData(string resourcePath, int requiredStatus, Method requestMethod, string rootElement, object formParams)
            : this(resourcePath, requiredStatus, requestMethod, rootElement)
        {
            FormParams = formParams;
        }

        public HttpWebRequest Request;
        public string ResourcePath;
        public int RequiredStatus;
        public Method RequestMethod;
        public string RootElement;
        public object FormParams;
    }
}
