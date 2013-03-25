using System;

namespace OneApi.Exceptions
{
    public class RequestException : Exception 
	{
        public string MessageId { get; private set; }
        public int ResponseCode { get; private set; }

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
            this.ResponseCode = responseCode;
		}

		public RequestException(string s, string messageId) : base(s)
		{
            this.MessageId = messageId;
		}

		public RequestException(string errorText, string messageId, int responseCode) : this(errorText)
		{
            this.MessageId = messageId;
			this.ResponseCode = responseCode;
		}
	}
}