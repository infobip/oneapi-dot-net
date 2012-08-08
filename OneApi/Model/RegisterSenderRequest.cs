namespace org.oneapi.model
{

	/// 
	/// <summary>
	/// @author vavukovic
	/// 
	/// </summary>
	public class RegisterSenderRequest
	{
		private string gsmNumber;
		private string description;

		public RegisterSenderRequest()
		{
		}

		public RegisterSenderRequest(string gsmNumber)
		{
			this.gsmNumber = gsmNumber;
		}

		public RegisterSenderRequest(string gsmNumber, string description)
		{
			this.gsmNumber = gsmNumber;
			this.description = description;
		}

		public virtual string GsmNumber
		{
			get
			{
				return gsmNumber;
			}
			set
			{
				this.gsmNumber = value;
			}
		}


		public virtual string Description
		{
			get
			{
				return description;
			}
			set
			{
				this.description = value;
			}
		}


		public override string ToString()
		{
			return "RegisterSenderRequest {gsmNumber=" + gsmNumber + ", description=" + description + "}";
		}
	}

}