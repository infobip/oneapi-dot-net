using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace OneApi.Model
{
    [Serializable]
    public class RoamingNotification
    {
        [JsonProperty(PropertyName = "roaming")]
        public RoamingAsync Roaming;

        [JsonProperty(PropertyName = "callbackData")]
        public string CallbackData;

        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append("roaming = ");
            buffer.Append(Roaming);
            buffer.Append(", callbackData = ");
            buffer.Append(CallbackData);
            return buffer.ToString();
        }
    }
}
