namespace org.oneapi.model
{

	/// 
	/// <summary>
	/// @author vavukovic
	/// 
	/// </summary>
	public class VerifyUserRequest
	{
		private string verificationCode;

		public VerifyUserRequest()
		{
		}

		public VerifyUserRequest(string verificationCode)
		{
			this.verificationCode = verificationCode;
		}

		public virtual string VerificationCode
		{
			get
			{
				return verificationCode;
			}
			set
			{
				this.verificationCode = value;
			}
		}


		public override string ToString()
		{
			return "VerifyUserRequest {verificationCode=" + verificationCode + "}";
		}
	}

}