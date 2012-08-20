using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneApi.Model
{
    public class RequestData
    {
        public enum REQUEST_METHOD { POST = 1, PUT = 2, GET = 3, DELETE = 4 };
      
        private string apiUrl;
        private int requiredStatus;
        private REQUEST_METHOD requestMethod = REQUEST_METHOD.POST;
        private string rootElement = null;
        private object formParams = null;

        public RequestData(string apiUrl, int requiredStatus, REQUEST_METHOD requestMethod) {
            this.apiUrl = apiUrl;
            this.requiredStatus = requiredStatus;
            this.requestMethod = requestMethod;
        }

        public RequestData(string apiUrl, int requiredStatus, REQUEST_METHOD requestMethod, object formParams) : this(apiUrl, requiredStatus, requestMethod)
        {
            this.formParams = formParams;
        }

        public RequestData(string apiUrl, int requiredStatus, REQUEST_METHOD requestMethod, string rootElement)
            : this(apiUrl, requiredStatus, requestMethod)
        {
            this.rootElement = rootElement;
        }

        public RequestData(string apiUrl, int requiredStatus, REQUEST_METHOD requestMethod, string rootElement, object formParams) : this(apiUrl, requiredStatus, requestMethod, rootElement) 
        {
            this.formParams = formParams;
        }

        public string ApiUrl
        {
            get { return apiUrl; }
            set { apiUrl = value; }
        }

        public int RequiredStatus
        {
            get { return requiredStatus; }
            set { requiredStatus = value; }
        }

        public REQUEST_METHOD RequestMethod
        {
            get { return requestMethod; }
            set { requestMethod = value; }
        }

        public string RootElement
        {
            get { return rootElement; }
            set { rootElement = value; }
        }

        public object FormParams
        {
            get { return formParams; }
            set { formParams = value; }
        }
    }
}
