using System.ComponentModel;

namespace OneApi.Model
{
	public class SubscribeToInboundMessagesRequest
	{
        /// <summary>
        /// (mandatory) is the address/ MSISDN, or code agreed with the operator, to which people may send an SMS to your application </summary>
        /// <returns> destinationAddress </returns>
        [DisplayName("destinationAddress")]
        public string DestinationAddress { get; set; }

        /// <summary>
        /// (mandatory) is the URL to which you would like a notification of message receipts sent </summary>
        /// <returns> notifyURL </returns>
        [DisplayName("notifyURL")]
        public string NotifyURL { get; set; }

        /// <summary>
        /// (optional) is case-insensitve text to match against the first word of the message, ignoring any leading whitespace. This allows you to reuse a short code among various applications, each of which can register their own subscription with different criteria </summary>
        /// <returns> criteria </returns>
        [DisplayName("criteria")]
        public string Criteria { get; set; }

        /// <summary>
        /// (optional) is the content type that notifications will be sent in Đ for OneAPI v1.0 only JSON is supported </summary>
        /// <returns> notificationFormat </returns>
        [DisplayName("notificationFormat")]
        public string NotificationFormat { get; set; }

        /// <summary>
        /// (optional) uniquely identifies this create subscription request. If there is a communication failure during the request, using the same clientCorrelator when retrying the request allows the operator to avoid creating a duplicate subscription </summary>
        /// <returns> clientCorrelator </returns>
        [DisplayName("clientCorrelator")]
        public string ClientCorrelator { get; set; }

        /// <summary>
        /// (optional) is a function name or other data that you would like included when the POST is sent to your application </summary>
        /// <param name="callbackData"> </param>
        [DisplayName("callbackData")]
        public string CallbackData { get; set; }

        /// <summary>
        /// Start subscribing to notifications of SMS messages sent to your application
        /// </summary>
		public SubscribeToInboundMessagesRequest()
		{
		}

		/// <summary>
		/// Start subscribing to notifications of SMS messages sent to your application </summary>
		/// <param name="destinationAddress"> is the address/ MSISDN, or code agreed with the operator, to which people may send an SMS to your application </param>
		/// <param name="notifyURL"> is the URL to which you would like a notification of message receipts sent </param>
		public SubscribeToInboundMessagesRequest(string destinationAddress, string notifyURL)
		{
            this.DestinationAddress = destinationAddress;
            this.NotifyURL = notifyURL;
		}

		/// <summary>
		/// Start subscribing to notifications of SMS messages sent to your application </summary>
		/// <param name="destinationAddress"> (mandatory) is the address/ MSISDN, or code agreed with the operator, to which people may send an SMS to your application </param>
		/// <param name="notifyURL"> (mandatory) is the URL to which you would like a notification of message receipts sent </param>
		/// <param name="criteria"> (optional) is case-insensitve text to match against the first word of the message, ignoring any leading whitespace. This allows you to reuse a short code among various applications, each of which can register their own subscription with different criteria </param>
		/// <param name="notificationFormat"> (optional) is the content type that notifications will be sent in Đ for OneAPI v1.0 only JSON is supported </param>
		/// <param name="clientCorrelator"> (optional) uniquely identifies this create subscription request. If there is a communication failure during the request, using the same clientCorrelator when retrying the request allows the operator to avoid creating a duplicate subscription </param>
		/// <param name="callbackData"> (optional) is a function name or other data that you would like included when the POST is sent to your application </param>
		public SubscribeToInboundMessagesRequest(string destinationAddress, string notifyURL, string criteria, string notificationFormat, string clientCorrelator, string callbackData)
            : this(destinationAddress, notifyURL)
		{
            this.Criteria = criteria;
            this.NotificationFormat = notificationFormat;
            this.ClientCorrelator = clientCorrelator;
            this.CallbackData = callbackData;
		}
	}
}