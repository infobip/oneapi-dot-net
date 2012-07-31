using System;
using System.Text;
using Newtonsoft.Json;

namespace OneApi.Model
{

	/// <summary>
	/// InboundMessage contains the main message information for an SMS message (not
	/// including attachment information)
	/// </summary>
	[Serializable]
	public class InboundSMSMessage
	{
		/// <summary>
		/// return the date/time that the SMS message was sent.
		/// </summary>
        [JsonProperty(PropertyName = "dateTime")]
        public String SubmitTime;

		/// <summary>
		/// return the recipient MSISDN or other identifying number
		/// </summary>
        [JsonProperty(PropertyName = "destinationAddress")]
        public string DestinationAddress;

		/// <summary>
		/// return the unique messageId for the message
		/// </summary>
        [JsonProperty(PropertyName = "messageId")]
        public string MessageId;

		/// <summary>
		/// return the SMS message body
		/// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message;

		/// <summary>
		/// return resourceURL containing a URL uniquely identifying this SMS message
		/// </summary>
        [JsonProperty(PropertyName = "resourceURL")]
        public string ResourceURL;

		/// <summary>
		/// return the sender MSISDN or other identifying number
		/// </summary>
        [JsonProperty(PropertyName = "senderAddress")]
        public string SenderAddress;

		/// <summary>
		/// default constructor
		/// </summary>
		public InboundSMSMessage(){}

		/// <summary>
		/// utility constructor to create an InboundMessage class with all fields set
		/// </summary>
        /// <param name="submitTime"> </param>
		/// <param name="destinationAddress"> </param>
		/// <param name="messageId"> </param>
		/// <param name="message"> </param>
		/// <param name="resourceURL"> </param>
		/// <param name="senderAddress"> </param>
        public InboundSMSMessage(String submitTime, string destinationAddress, string messageId, string message, string resourceURL, string senderAddress)
		{
            this.SubmitTime = submitTime;
			this.DestinationAddress = destinationAddress;
			this.MessageId = messageId;
			this.Message = message;
			this.ResourceURL = resourceURL;
			this.SenderAddress = senderAddress;
		}

		/// <summary>
		/// generate a textual representation of the InboundMessage including all
		/// nested elements and classes
		/// </summary>
        public override string ToString()
		{
			StringBuilder buffer = new StringBuilder();
            buffer.Append("submitTime = ");
            buffer.Append(SubmitTime);
			buffer.Append(", destinationAddress = ");
			buffer.Append(DestinationAddress);
			buffer.Append(", messageId = ");
			buffer.Append(MessageId);
			buffer.Append(", message = ");
			buffer.Append(Message);
			buffer.Append(", resourceURL = ");
			buffer.Append(ResourceURL);
			buffer.Append(", senderAddress = ");
			buffer.Append(SenderAddress);
			return buffer.ToString();
		}
	}
}