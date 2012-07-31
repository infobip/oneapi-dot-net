using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace OneApi.Model
{
    [Serializable]
    public class DeliveryInfoNotification
    {
        [JsonProperty(PropertyName = "deliveryInfo")]
        public OneApi.Model.DeliveryInfoList.DeliveryInfo DeliveryInfo;

        [JsonProperty(PropertyName = "callbackData")]
        public string CallbackData;

        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append("deliveryInfo = ");
            buffer.Append(DeliveryInfo);
            buffer.Append(", callbackData = ");
            buffer.Append(CallbackData);
            return buffer.ToString();
        }
    }
}
