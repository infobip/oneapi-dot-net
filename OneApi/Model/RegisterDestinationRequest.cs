namespace org.oneapi.model
{

	/// 
	/// <summary>
	/// @author vavukovic
	/// 
	/// </summary>
	public class RegisterDestinationRequest
	{
		private string gsmNumber;

		public RegisterDestinationRequest()
		{
		}

		public RegisterDestinationRequest(string gsmNumber)
		{
			this.gsmNumber = gsmNumber;
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


		public override string ToString()
		{
			return "RegisterDestinationRequest{" + "gsmNumber='" + gsmNumber + '\'' + '}';
		}
	}

}