using System;
using Newtonsoft.Json;

namespace OneApi.Model
{

	[Serializable]
	public class DeliveryReport
	{
        [JsonProperty(PropertyName = "messageId")]
        public string MessageId;

        [JsonProperty(PropertyName = "sentDate")]
        public DateTime SentDate;

        [JsonProperty(PropertyName = "doneDate")]
        public DateTime DoneDate;

        [JsonProperty(PropertyName = "status")]
        public string Status;

        [JsonProperty(PropertyName = "price")]
        public decimal? Price;

		public override string ToString()
		{
            return "DeliveryReport {messageId=" + MessageId + ", sentDate="
            + SentDate + ", doneDate=" + DoneDate + ", status=" + Status + ", price=" + Price
            + "}";
		}
	}
}