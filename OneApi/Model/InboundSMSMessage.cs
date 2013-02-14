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
        [JsonConverter(typeof(CustomDateConverter))]
        public DateTime SubmitTime;

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

     
        [JsonProperty(PropertyName = "moSessionId")]
        public int MoSessionId;

        [JsonProperty(PropertyName = "moResponseKey")]
        public string MoResponseKey;

        [JsonProperty(PropertyName = "callbackData")]
        public string CallbackData;

        [JsonProperty(PropertyName = "price")]
        public double Price;

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
        /// <param name="moSessionId"> </param>
        public InboundSMSMessage(DateTime submitTime, string destinationAddress, string messageId, string message, string resourceURL, string senderAddress, int moSessionId)
		{
            this.SubmitTime = submitTime;
			this.DestinationAddress = destinationAddress;
			this.MessageId = messageId;
			this.Message = message;
			this.ResourceURL = resourceURL;
			this.SenderAddress = senderAddress;
            this.MoSessionId = moSessionId;
		}

		/// <summary>
		/// generate a textual representation of the InboundMessage including all
		/// nested elements and classes
		/// </summary>
        public override string ToString()
		{
            return "InboundSMSMessage {dateTime=" + SubmitTime
                + ", destinationAddress=" + DestinationAddress + ", messageId="
                + MessageId + ", message=" + Message + ", resourceURL="
                + ResourceURL + ", senderAddress=" + SenderAddress
                + ", moSessionId=" + MoSessionId 
                + ", moResponseKey=" + MoResponseKey 
                + ", callbackData=" + CallbackData 
                + ", price=" + Price +
                "}";
		}
	}
}