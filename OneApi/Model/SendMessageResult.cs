using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

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
                    + ", sendMessageResults=" + string.Join(", ", (Object[])SendMessageResults)
                    + ", resourceReference=" + ResourceRef + "}";
        }
    }
}
