namespace OneApi.Model
{
	public class LoginResponse
	{
		private bool verified;
		private string ibAuthCookie;

		public LoginResponse()
		{
		}

        public bool Verified;
        public string IbAuthCookie;
		
		public override string ToString()
		{
			return this.GetType().Name + "{" + "verified=" + verified + ", ibAuthCookie='" + ibAuthCookie + '\'' + '}';
		}
	}

}