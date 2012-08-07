namespace OneApi.Model
{
	public class LoginResponse
	{
		public LoginResponse()
		{
		}

        public bool Verified;
        public string IbAuthCookie;
		
		public override string ToString()
		{
            return this.GetType().Name + "{" + "verified=" + Verified + ", ibAuthCookie='" + IbAuthCookie + '\'' + '}';
		}
	}

}