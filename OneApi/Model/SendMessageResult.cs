using System;
using Newtonsoft.Json;
using System.Linq;

namespace OneApi.Model
{
    public class SendMessageResult
    {
        [JsonProperty(PropertyName = "clientCorrelator")]
        public String ClientCorrelator;

        [JsonProperty(PropertyName = "sendMessageResults")]
        public SendMessageResultItem[] SendMessageResults;

        [JsonProperty(PropertyName = "resourceReference")]
        public ResourceReference ResourceRef;

        public override string ToString()
        {
            return "SendMessageResult {clientCorrelator=" + ClientCorrelator
                + ", sendMessageResults=" + string.Join(", ", 
                SendMessageResults.Select<SendMessageResultItem, string>(smr => smr != null ? smr.ToString() : "{}")
                    .ToArray()) + ", resourceReference=" + ResourceRef + "}";
        }
    }
}
