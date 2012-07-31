using Newtonsoft.Json;

namespace OneApi.Model
{
	public class MoSubscription
	{
        [JsonProperty(PropertyName = "subscriptionId")]
        public string SubscriptionId;

        [JsonProperty(PropertyName = "callbackData")]
        public string CallbackData;

        [JsonProperty(PropertyName = "criteria")]
        public string Criteria;

        [JsonProperty(PropertyName = "destinationAddress")]
        public string DestinationAddress;

        [JsonProperty(PropertyName = "notificationFormat")]
        public string NotificationFormat;

        [JsonProperty(PropertyName = "notifyURL")]
        public string NotifyURL;

		public override string ToString()
		{
			return "MoSubscription {subscriptionId=" + SubscriptionId + ", notifyURL=" + NotifyURL + ", callbackData=" + CallbackData + ", criteria=" + Criteria + ", destinationAddress=" + DestinationAddress + ", notificationFormat=" + NotificationFormat + "}";
		}
	}
}