using System;
using System.Text;
using Newtonsoft.Json;

namespace OneApi.Model
{

	/// <summary>
	/// InboundMessageList contains the detail of the response to get a list of
	/// received SMS messages
	/// </summary>
	[Serializable]
	public class InboundSMSMessageList
	{
		/// <summary>
		/// return the inboundSMSMessage array
		/// </summary>
        [JsonProperty(PropertyName = "inboundSMSMessage")]
        public InboundSMSMessage[] InboundSMSMessage;

		/// <summary>
		/// return the number of messages returned for this batch
		/// </summary>
        [JsonProperty(PropertyName = "numberOfMessagesInThisBatch")]
        public int NumberOfMessagesInThisBatch;

		/// <summary>
		/// return resourceURL containing a URL uniquely identifying this MMS message
		/// list
		/// </summary>
        [JsonProperty(PropertyName = "resourceURL")]
        public string ResourceURL;

		/// <summary>
		/// return the totalNumberOfPendingMessages awaiting retrieval from gateway
		/// storage
		/// </summary>
        [JsonProperty(PropertyName = "totalNumberOfPendingMessages")]
        public int TotalNumberOfPendingMessages;

        [JsonProperty(PropertyName = "callbackData")]
        public string CallbackData;

		/// <summary>
		/// generate a textual representation of the inboundSMSMessageList instance
		/// including nested elements and classes
		/// </summary>
        public override string ToString()
		{
			StringBuilder buffer = new StringBuilder();
			buffer.Append("numberOfMessagesInThisBatch = ");
			buffer.Append(NumberOfMessagesInThisBatch);
			buffer.Append(", resourceURL = ");
			buffer.Append(ResourceURL);
			buffer.Append(", totalNumberOfPendingMessages = ");
			buffer.Append(TotalNumberOfPendingMessages);
            buffer.Append(", callbackData = ");
            buffer.Append(CallbackData);

			buffer.Append(", inboundSMSMessage = {");
			if (InboundSMSMessage != null)
			{
                for (int i = 0; i < InboundSMSMessage.Length; i++)
				{
					buffer.Append("[");
					buffer.Append(i);
					buffer.Append("] = {");
                    buffer.Append(InboundSMSMessage[i].ToString());
					buffer.Append("} ");
				}
			}
			buffer.Append("} ");

			return buffer.ToString();

		}
	}

}