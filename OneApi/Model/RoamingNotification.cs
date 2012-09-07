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
        public Roaming Roaming;

        [JsonProperty(PropertyName = "callbackData")]
        public string CallbackData;

        public override string ToString()
        {
            return "RoamingNotification {roaming=" + Roaming + ", callbackData="
                  + CallbackData + "}";
        }
    }
}
