namespace org.oneapi.model
{

	/// 
	/// <summary>
	/// @author vavukovic
	/// 
	/// </summary>
	public class VerifySenderRequest
	{
		private string gsmNumber;
		private string code;

		public VerifySenderRequest()
		{
		}

		public VerifySenderRequest(string gsmNumber, string code)
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
			return "VerifySenderRequest {gsmNumber=" + gsmNumber + ", code=" + code + "}";
		}
	}

}