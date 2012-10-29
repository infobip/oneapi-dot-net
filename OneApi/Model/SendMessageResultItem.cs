using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace OneApi.Model
{
    public class SendMessageResultItem
    {
        [JsonProperty(PropertyName = "messageStatus")]
        public String MessageStatus;

        [JsonProperty(PropertyName = "messageId")]
        public String MessageId;

        [JsonProperty(PropertyName = "senderAddress")]
        public String SenderAddress;

        [JsonProperty(PropertyName = "destinationAddress")]
        public String DestinationAddress;

        public override string ToString()
        {
            return "SendMessageResultItem {messageStatus=" + MessageStatus
                + ", messageId=" + MessageId + ", senderAddress="
                + SenderAddress + ", destinationAddress=" + DestinationAddress
                + "}";
        }
    }
}
