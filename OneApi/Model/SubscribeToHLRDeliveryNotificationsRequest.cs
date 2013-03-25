using System.ComponentModel;

namespace OneApi.Model
{
	public class SubscribeToHLRDeliveryNotificationsRequest
	{
        [DisplayName("notifyURL")]
        public string NotifyURL { get; set; }

        [DisplayName("callbackData")]
        public string CallbackData { get; set; }

        [DisplayName("clientCorrelator")]
        public string ClientCorrelator { get; set; }

		public SubscribeToHLRDeliveryNotificationsRequest()
		{
		}

		public SubscribeToHLRDeliveryNotificationsRequest(string notifyURL)
		{
            this.NotifyURL = notifyURL;
		}

		public SubscribeToHLRDeliveryNotificationsRequest(string notifyURL, string callbackData, string clientCorrelator)
            : this(notifyURL)
		{
            this.CallbackData = callbackData;
            this.ClientCorrelator = clientCorrelator;
		}
	}
}