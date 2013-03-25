using System.ComponentModel;

namespace OneApi.Model
{
	public class USSDRequest
	{
        [DisplayName("address")]
        public string Address { get; set; }

        [DisplayName("message")]
        public string Message { get; set; }

        [DisplayName("stopSession")]
        public bool StopSession { get; set; }

        public USSDRequest()
        {
        }

        public USSDRequest(string address, string message)
        {
            this.Address = address;
            this.Message = message;
        }

        public USSDRequest(string address, string message, bool stopSession)
            : this(address, message)
		{
            this.StopSession = stopSession;
		}
	}
}