using System.ComponentModel;

namespace OneApi.Model
{

	public class SubscribeToDeliveryNotificationsRequest
	{
		private string senderAddress = null;
		private string notifyURL = null;
		private string criteria = null;
		private string clientCorrelator = null;
		private string callbackData = null;

		public SubscribeToDeliveryNotificationsRequest()
		{
		}

		/// <summary>
		/// Start subscribing to delivery status notifications over OneAPI for all your sent SMS </summary>
		/// <param name="senderAddress"> is the address from which SMS messages are being sent. Do not URL encode this value prior to passing to this function </param>
		/// <param name="notifyURL"> is the URL to which you would like a notification of delivery sent </param>
		public SubscribeToDeliveryNotificationsRequest(string senderAddress, string notifyURL)
		{
			this.senderAddress = senderAddress;
			this.notifyURL = notifyURL;
		}

		/// <summary>
		/// Start subscribing to delivery status notifications over OneAPI for all your sent SMS </summary>
		/// <param name="senderAddress"> (mandatory) is the address from which SMS messages are being sent. Do not URL encode this value prior to passing to this function </param>
		/// <param name="notifyURL"> (mandatory) is the URL to which you would like a notification of delivery sent </param>
		/// <param name="criteria"> (optional) Text in the message to help you route the notification to a specific application. For example you may ask users to ‘text GIGPICS to 12345′ for your rock concert photos application. This text is matched against the first word, as defined as the initial characters after discarding any leading Whitespace and ending with a Whitespace or end of the string. The matching shall be case-insensitive. </param>
		/// <param name="clientCorrelator"> (optional) uniquely identifies this subscription request. If there is a communication failure during the request, using the same clientCorrelator when retrying the request allows the operator to avoid setting up the same subscription twice </param>
		/// <param name="callbackData"> (optional) will be passed back to the notifyURL location, so you can use it to identify the message the delivery receipt relates to (or any other useful data, such as a function name) </param>
		public SubscribeToDeliveryNotificationsRequest(string senderAddress, string notifyURL, string criteria, string clientCorrelator, string callbackData)
		{
			this.senderAddress = senderAddress;
			this.notifyURL = notifyURL;
			this.criteria = criteria;
			this.clientCorrelator = clientCorrelator;
			this.callbackData = callbackData;
		}

		/// <summary>
		/// (mandatory) is the address from which SMS messages are being sent. Do not URL encode this value prior to passing to this function </summary>
		/// <returns> senderAddress </returns>
        [DisplayName("senderAddress")]
        public virtual string SenderAddress
		{
			get
			{
				return senderAddress;
			}
			set
			{
				this.senderAddress = value;
			}
		}

		/// <summary>
		/// (mandatory) is the URL to which you would like a notification of delivery sent </summary>
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
		/// criteria (optional) Text in the message to help you route the notification to a specific application. For example you may ask users to ‘text GIGPICS to 12345′ for your rock concert photos application. This text is matched against the first word, as defined as the initial characters after discarding any leading Whitespace and ending with a Whitespace or end of the string. The matching shall be case-insensitive. </summary>
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
		/// (optional) optional) uniquely identifies this subscription request. If there is a communication failure during the request, using the same clientCorrelator when retrying the request allows the operator to avoid setting up the same subscription twice </summary>
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
		/// (optional) will be passed back to the notifyURL location, so you can use it to identify the message the delivery receipt relates to (or any other useful data, such as a function name) </summary>
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