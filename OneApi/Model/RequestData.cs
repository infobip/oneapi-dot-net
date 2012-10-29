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
        public RequestData(string resourcePath, Method requestMethod)
        {
            ResourcePath = resourcePath;
            RequestMethod = requestMethod;
        }

        public RequestData(string apiUrl, Method requestMethod, object formParams)
            : this(apiUrl, requestMethod)
        {
            this.FormParams = formParams;
        }

        public RequestData(string resourcePath, Method requestMethod, string rootElement)
            : this(resourcePath, requestMethod)
        {
            RootElement = rootElement;
        }

        public RequestData(string resourcePath, Method requestMethod, string rootElement, object formParams)
            : this(resourcePath, requestMethod, rootElement)
        {
            FormParams = formParams;
        }

        public HttpWebRequest Request;
        public string ResourcePath;
        public Method RequestMethod;
        public string RootElement;
        public object FormParams;
    }
}
