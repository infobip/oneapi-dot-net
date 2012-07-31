using System;
using System.Text;

namespace OneApi.Model
{

	/// <summary>
	/// specific error case indicated by the OneAPI server as a Policy Exception
	/// </summary>
	/// <seealso cref= CommonPolicyExceptionType </seealso>
	[Serializable]
	public class PolicyException
	{
		/// <summary>
		/// return the distinctive error message identifier
		/// </summary>
        public string MessageId;

		/// <summary>
		/// return the textual representation of the error
		/// </summary>
        public string Text;

		/// <summary>
		/// return any instance specific error variables
		/// </summary>
        public string[] Variables;


		/// <summary>
		/// default constructor
		/// </summary>
		public PolicyException(){}

		/// <summary>
		/// utility constructor to create a ServiceException object with all fields set </summary>
		/// <param name="messageId"> </param>
		/// <param name="text"> </param>
		/// <param name="variables"> </param>
		public PolicyException(string messageId, string text, string[] variables)
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