using System;
using System.Text;
using Newtonsoft.Json;

namespace OneApi.Model
{

	/// <summary>
	/// contains an error response returned from the OneAPI server
	/// </summary>
	[Serializable]
	public class RequestError
	{
		/// <summary>
		/// internally used to indicate the type of exception being stored is a ServiceException
		/// </summary>
		public const int SERVICEEXCEPTION = 1;
		/// <summary>
		/// internally used to indicate the type of exception being stored is a PolicyException
		/// </summary>
		public const int POLICYEXCEPTION = 2;

        /**
	    * instance of a ServiceException
	    */
	    private ServiceException serviceException=null;
	    /** 
	     * instance of a PolicyException
	    */
	    private PolicyException policyException=null;

		/// <summary>
		/// return the clientCorrelator
		/// </summary>
        [JsonProperty(PropertyName = "clientCorrelator")]
        public string ClientCorrelator;

        [JsonProperty(PropertyName = "serviceException")]
        public ServiceException ServiceException
		{
			get
			{
				return serviceException;
			}
			set
			{
                ExceptionType = SERVICEEXCEPTION;
				serviceException = value;
			}
		}

        [JsonIgnore]
        public int ExceptionType;

        [JsonIgnore]
        public int HttpResponseCode;

		/// <summary>
		/// return the policyException instance
		/// </summary>
        [JsonProperty(PropertyName = "policyException")]
		public PolicyException PolicyException
		{
			get
			{
				return policyException;
			}
			set
			{
				this.policyException = value;
				ExceptionType = POLICYEXCEPTION;
			}
		}

		/// <summary>
		/// utility constructor to create an RequestError instance with all fields set </summary>
		/// <param name="type"> </param>
		/// <param name="httpResponseCode"> </param>
		/// <param name="messageId"> </param>
		/// <param name="text"> </param>
		/// <param name="variables"> </param>
		public RequestError(int type, int httpResponseCode, string messageId, string clientCorrelator, string text, params string[] variables)
		{
			if (type == SERVICEEXCEPTION)
			{
				serviceException = new ServiceException();
				serviceException.MessageId = messageId;
				serviceException.Text = text;
				serviceException.Variables = variables;
			}
			else if (type == POLICYEXCEPTION)
			{
				policyException = new PolicyException();
				policyException.MessageId = messageId;
				policyException.Text = text;
				policyException.Variables = variables;
			}
			ExceptionType = type;
			ClientCorrelator = clientCorrelator;
			HttpResponseCode = httpResponseCode;
		}

		/// <summary>
		/// default constructor
		/// </summary>
		public RequestError()
		{
            HttpResponseCode = 400;
            ExceptionType = 0;
		}

		/// <summary>
		/// generate a textual representation of the RequestError including all nested elements and classes 
		/// </summary>
        public override string ToString()
		{
			StringBuilder buffer = new StringBuilder();
			if (ClientCorrelator != null)
			{
				buffer.Append("clientCorrelator=");
				buffer.Append(ClientCorrelator);
			}
			if (serviceException != null)
			{
				buffer.Append("serviceException = {");
				buffer.Append("messageId = ");
				buffer.Append(serviceException.MessageId);
				buffer.Append(", text = ");
				buffer.Append(serviceException.Text);
				buffer.Append(", variables = ");
				if (serviceException.Variables != null)
				{
					buffer.Append("{");
					for (int i = 0; i < serviceException.Variables.Length; i++)
					{
						buffer.Append("[");
						buffer.Append(i);
						buffer.Append("] = ");
						buffer.Append(serviceException.Variables[i]);
					}
					buffer.Append("}");
				}
				buffer.Append("}");
			}
			if (policyException != null)
			{
				buffer.Append("policyException = {");
				buffer.Append("messageId = ");
				buffer.Append(policyException.MessageId);
				buffer.Append(", text = ");
				buffer.Append(policyException.Text);
				buffer.Append(", variables = ");
				if (policyException.Variables != null)
				{
					buffer.Append("{");
					for (int i = 0; i < policyException.Variables.Length; i++)
					{
						buffer.Append("[");
						buffer.Append(i);
						buffer.Append("] = ");
						buffer.Append(policyException.Variables[i]);
					}
					buffer.Append("}");
				}
				buffer.Append("}");
			}

			return buffer.ToString();
		}
	}
}