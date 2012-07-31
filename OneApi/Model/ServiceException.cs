using System;
using System.Text;
using Newtonsoft.Json;

namespace OneApi.Model
{

	/// <summary>
	/// specific error case indicated by the OneAPI server as a Service Exception
	/// </summary>
	[Serializable]
	public class ServiceException
	{
		/// <summary>
		/// return the distinctive error message identifier
		/// </summary>
        [JsonProperty(PropertyName = "messageId")]
        public string MessageId;
			
		/// <summary>
		/// return the textual representation of the error
		/// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text;

		/// <summary>
		/// return any instance specific error variables
		/// </summary>
        [JsonProperty(PropertyName = "variables")]
        public string[] Variables;


		/// <summary>
		/// default constructor
		/// </summary>
		public ServiceException(){}

		/// <summary>
		/// utility constructor to create a ServiceException object with all fields set </summary>
		/// <param name="messageId"> </param>
		/// <param name="text"> </param>
		/// <param name="variables"> </param>
		public ServiceException(string messageId, string text, string[] variables)
		{
			MessageId = messageId;
			Text = text;
			Variables = variables;
		}

		/// <summary>
		/// generate a textual representation of the ServiceException instance  
		/// </summary>
        public override string ToString()
		{
			StringBuilder buffer = new StringBuilder();
			buffer.Append("messageId = ");
			buffer.Append(MessageId);
			buffer.Append(", text = ");
			buffer.Append(Text);
			buffer.Append(", variables = {");
			if (Variables != null)
			{
				for (int i = 0; i < Variables.Length; i++)
				{
					buffer.Append("[");
					buffer.Append(i);
					buffer.Append("] = ");
					buffer.Append(Variables[i]);
				}
			}
			buffer.Append("}");
			return buffer.ToString();
		}
	}
}