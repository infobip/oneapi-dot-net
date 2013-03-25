using System;
using Newtonsoft.Json;

namespace OneApi.Model
{
    [Serializable]
    public class RoamingNotification
    {
        [JsonProperty(PropertyName = "roaming")]
        public Roaming Roaming { get; set; }

        [JsonProperty(PropertyName = "callbackData")]
        public string CallbackData { get; set; }

        public override string ToString()
        {
            return "RoamingNotification {roaming=" + Roaming + ", callbackData="
                  + CallbackData + "}";
        }
    }
}
