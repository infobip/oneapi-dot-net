namespace org.oneapi.model
{

	/// 
	/// <summary>
	/// @author vavukovic
	/// 
	/// </summary>
	public class VerifyDestinationRequest
	{
		private string gsmNumber;
		private string code;

		public VerifyDestinationRequest()
		{
		}

		public VerifyDestinationRequest(string gsmNumber, string code)
		{
			this.gsmNumber = gsmNumber;
			this.code = code;
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


		public virtual string Code
		{
			get
			{
				return code;
			}
			set
			{
				this.code = value;
			}
		}


		public override string ToString()
		{
			return "VerifyDestinationRequest {gsmNumber=" + gsmNumber + ", code=" + code + "}";
		}
	}

}