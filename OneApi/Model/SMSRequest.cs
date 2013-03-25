using System.ComponentModel;

namespace OneApi.Model
{
	public class SMSRequest
	{
        /// <summary>
        /// (mandatory) is the address to whom a responding SMS may be sent </summary>
        /// <returns> senderAddress </returns>
        /// 
        [DisplayName("senderAddress")]
        public string SenderAddress { get; set; }

        /// <summary>
        /// (mandatory) contains one address for end user ID to send to </summary>
        /// <returns> recipientsAddress </returns>
        [DisplayName("address")]
        public string[] Address { get; set; }

        /// <summary>
        /// (mandatory) contains the message text to send
        /// @return
        /// </summary>
        [DisplayName("message")]
        public string Message { get; set; }

        /// <summary>
        /// (optional) uniquely identifies this create MMS request. If there is a communication failure during the request, using the same clientCorrelator when retrying the request allows the operator to avoid sending the same MMS twice. </summary>
        /// <returns> clientCorrelator </returns>
        [DisplayName("clientCorrelator")]
        public string ClientCorrelator { get; set; }

        /// <summary>
        /// (optional) is the URL to which you would like a notification of delivery sent </summary>
        /// <returns> notifyURL </returns>
        /// 
        [DisplayName("notifyURL")]
        public string NotifyURL { get; set; }

        /// <summary>
        /// (optional) is the name to appear on the user's terminal as the sender of the message </summary>
        /// <returns> senderName </returns>

        [DisplayName("senderName")]
        public string SenderName { get; set; }

        /// <summary>
        /// (optional) will be passed back to the notifyURL location, so you can use it to identify the message the receipt relates to (or any other useful data, such as a function name) </summary>
        /// <param name="callbackData"> </param>
        [DisplayName("callbackData")]
        public string CallbackData { get; set; }

		public SMSRequest()
		{
		}

		/// <summary>
        /// Initialize SMSRequest object using mandatory parameters </summary>
		/// <param name="senderAddress"> is the address to whom a responding SMS may be sent </param>
		/// <param name="recipientAddress"> contains one or more addresses for end user ID to send to </param>
		/// <param name="message"> contains the message text to send </param>
		public SMSRequest(string senderAddress, string message, params string[] recipientAddress)
		{
			this.SenderAddress = senderAddress;
			this.Message = message;
			this.Address = recipientAddress;
		}

		/// <summary>
        /// Initialize SMSRequest object using mandatory and optional parameters </summary>
		/// <param name="senderAddress"> is the address to whom a responding SMS may be sent </param>
		/// <param name="recipientAddress"> contains one or more addresses for end user ID to send to </param>
		/// <param name="message"> contains the message text to send </param>
		/// <param name="clientCorrelator"> uniquely identifies this create MMS request. If there is a communication failure during the request, using the same clientCorrelator when retrying the request allows the operator to avoid sending the same MMS twice. </param>
		/// <param name="notifyURL"> is the URL to which you would like a notification of delivery sent </param>
		/// <param name="senderName"> is the name to appear on the user's terminal as the sender of the message </param>
		/// <param name="callbackData"> will be passed back to the notifyURL location, so you can use it to identify the message the receipt relates to (or any other useful data, such as a function name) </param>
		public SMSRequest(string senderAddress, string message, string clientCorrelator, string notifyURL, string senderName, string callbackData, params string[] recipientAddress)
            : this(senderAddress, message, recipientAddress)
		{
			this.ClientCorrelator = clientCorrelator;
			this.NotifyURL = notifyURL;
			this.SenderName = senderName;
			this.CallbackData = callbackData;
		}
	}
}