using System;

namespace OneApi.Exceptions
{

    public class RequestException : Exception 
	{
		private const long serialVersionUID = 1L;

		private string messageId;
		private int responseCode;

		public RequestException()
		{
		}

		public RequestException(string s) : base(s)
		{
		}

        public RequestException(Exception e) : base(e.Message, e)
        {
        }

		public RequestException(string s, Exception e) : base(s, e)
		{
		}

		public RequestException(Exception e, int responseCode) : base(e.Message, e)
		{
			this.responseCode = responseCode;
		}

		public RequestException(string s, string messageId) : base(s)
		{
			this.messageId = messageId;
		}

		public RequestException(string errorText, string messageId, int responseCode) : this(errorText)
		{
			this.messageId = messageId;
			this.responseCode = responseCode;
		}

		public virtual string MessageId
		{
			get
			{
				return messageId;
			}
		}

		public virtual int ResponseCode
		{
			get
			{
				return responseCode;
			}
		}
	}

}