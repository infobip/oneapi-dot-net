using System.ComponentModel;

namespace OneApi.Model
{

	public class SubscribeToHLRDeliveryNotificationsRequest
	{
		private string notifyURL = null;
		private string callbackData = null;
		private string clientCorrelator = null;

		public SubscribeToHLRDeliveryNotificationsRequest()
		{
		}

		public SubscribeToHLRDeliveryNotificationsRequest(string notifyURL)
		{
			this.notifyURL = notifyURL;
		}

		public SubscribeToHLRDeliveryNotificationsRequest(string notifyURL, string callbackData, string clientCorrelator)
		{
			this.notifyURL = notifyURL;
			this.callbackData = callbackData;
			this.clientCorrelator = clientCorrelator;
		}

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

        [DisplayName("callbackData")]
		public virtual string CallbackData
		{
			get
			{
				return callbackData;
			}
			set
			{
				this.callbackData = value;
			}
		}

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
	}
}