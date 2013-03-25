using System;
using Newtonsoft.Json;

namespace OneApi.Model
{
    public class SendMessageResultItem
    {
        [JsonProperty(PropertyName = "messageStatus")]
        public String MessageStatus { get; set; }

        [JsonProperty(PropertyName = "messageId")]
        public String MessageId { get; set; }

        [JsonProperty(PropertyName = "senderAddress")]
        public String SenderAddress { get; set; }

        [JsonProperty(PropertyName = "destinationAddress")]
        public String DestinationAddress { get; set; }

        public override string ToString()
        {
            return "SendMessageResultItem {messageStatus=" + MessageStatus
                + ", messageId=" + MessageId + ", senderAddress="
                + SenderAddress + ", destinationAddress=" + DestinationAddress
                + "}";
        }
    }
}
