using System;
using Newtonsoft.Json;

namespace OneApi.Model
{
    public class SendMessageResult
    {
        [JsonProperty(PropertyName = "clientCorrelator")]
        public String ClientCorrelator { get; set; }

        [JsonProperty(PropertyName = "sendMessageResults")]
        public SendMessageResultItem[] SendMessageResults { get; set; }

        [JsonProperty(PropertyName = "resourceReference")]
        public ResourceReference ResourceRef { get; set; }

        public override string ToString()
        {
            return "SendMessageResult {clientCorrelator=" + ClientCorrelator
                    + ", sendMessageResults=" + string.Join(", ", (Object[])SendMessageResults)
                    + ", resourceReference=" + ResourceRef + "}";
        }
    }
}
