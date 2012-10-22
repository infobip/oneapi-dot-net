using System.ComponentModel;

namespace OneApi.Model
{

	public class SubscribeToInboundMessagesRequest
	{
        private string destinationAddress = null;
		private string notifyURL = null;
		private string criteria = null;
		private string notificationFormat = null;
		private string clientCorrelator = null;
		private string callbackData = null;

		public SubscribeToInboundMessagesRequest()
		{
		}

		/// <summary>
		/// Start subscribing to notifications of SMS messages sent to your application </summary>
		/// <param name="destinationAddress"> is the address/ MSISDN, or code agreed with the operator, to which people may send an SMS to your application </param>
		/// <param name="notifyURL"> is the URL to which you would like a notification of message receipts sent </param>
		public SubscribeToInboundMessagesRequest(string destinationAddress, string notifyURL)
		{
			this.destinationAddress = destinationAddress;
			this.notifyURL = notifyURL;
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
		{
			this.destinationAddress = destinationAddress;
			this.notifyURL = notifyURL;
			this.criteria = criteria;
			this.notificationFormat = notificationFormat;
			this.criteria = criteria;
			this.clientCorrelator = clientCorrelator;
			this.callbackData = callbackData;

		}

		/// <summary>
		/// (mandatory) is the address/ MSISDN, or code agreed with the operator, to which people may send an SMS to your application </summary>
		/// <returns> destinationAddress </returns>
        [DisplayName("destinationAddress")]
        public virtual string DestinationAddress
		{
			get
			{
				return destinationAddress;
			}
			set
			{
				this.destinationAddress = value;
			}
		}

		/// <summary>
		/// (mandatory) is the URL to which you would like a notification of message receipts sent </summary>
		/// <returns> notifyURL </returns>
        [DisplayName("notifyURL")]
        public virtual string NotifyURL
		{
			get
			{
				return notifyURL;
			}
			set
			{
				this.notifyURL = value;
			}
		}

		/// <summary>
		/// (optional) is case-insensitve text to match against the first word of the message, ignoring any leading whitespace. This allows you to reuse a short code among various applications, each of which can register their own subscription with different criteria </summary>
		/// <returns> criteria </returns>
        [DisplayName("criteria")]
        public virtual string Criteria
		{
			get
			{
				return criteria;
			}
			set
			{
				this.criteria = value;
			}
		}

		/// <summary>
		/// (optional) is the content type that notifications will be sent in Đ for OneAPI v1.0 only JSON is supported </summary>
		/// <returns> notificationFormat </returns>
        [DisplayName("notificationFormat")]
        public virtual string NotificationFormat
		{
			get
			{
				return notificationFormat;
			}
			set
			{
				this.notificationFormat = value;
			}
		}

		/// <summary>
		/// (optional) uniquely identifies this create subscription request. If there is a communication failure during the request, using the same clientCorrelator when retrying the request allows the operator to avoid creating a duplicate subscription </summary>
		/// <returns> clientCorrelator </returns>
        [DisplayName("clientCorrelator")]
        public virtual string ClientCorrelator
		{
			get
			{
				return clientCorrelator;
			}
			set
			{
				this.clientCorrelator = value;
			}
		}

		/// <summary>
		/// (optional) is a function name or other data that you would like included when the POST is sent to your application </summary>
		/// <param name="callbackData"> </param>
        [DisplayName("callbackData")]
        public virtual string CallbackData
		{
			set
			{
				this.callbackData = value;
			}
			get
			{
				return callbackData;
			}
		}
	}
}