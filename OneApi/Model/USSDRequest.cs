using System.ComponentModel;

namespace OneApi.Model
{

	public class USSDRequest
	{
		private string address = null;
		private string message = null;
		private bool stopSession = false;
	
		public USSDRequest()
		{
		}

		public USSDRequest(string address, string message)
		{
			this.address = address;
			this.message = message;
		}

        public USSDRequest(string address, string message, bool stopSession)
		{
			this.address = address;
			this.message = message;
            this.stopSession = stopSession;
		}

        [DisplayName("address")]
        public virtual string Address
        {
            get
            {
                return address;
            }
            set
            {
                this.address = value;
            }
        }

        [DisplayName("message")]
        public virtual string Message
		{
			get
			{
                return message;
			}
			set
			{
                this.message = value;
			}
		}

        [DisplayName("stopSession")]
        public virtual bool StopSession
		{
			get
			{
                return stopSession;
			}
			set
			{
                this.stopSession = value;
			}
		}	
	}
}