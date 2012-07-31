using System;
using Newtonsoft.Json;

namespace OneApi.Model
{

    [Serializable]
    public class DeliveryReportSubscription
    {
        [JsonProperty(PropertyName = "subscriptionId")]
        public string SubscriptionId;

        [JsonProperty(PropertyName = "senderAddress")]
        public string SenderAddress;

        [JsonProperty(PropertyName = "criteria")]
        public string Criteria;

        [JsonProperty(PropertyName = "notifyUrl")]
        public string NotifyUrl;

        [JsonProperty(PropertyName = "callbackData")]
        public string CallbackData;


        public override string ToString()
        {
            return "DeliveryReportSubscription {subscriptionId=" + SubscriptionId
                + ", senderAddress=" + SenderAddress + ", criteria=" + Criteria
                + ", notifyUrl=" + NotifyUrl + ", callbackData=" + CallbackData
                + "}";
        }
    }
}