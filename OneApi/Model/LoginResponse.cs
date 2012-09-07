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
            return "LoginResponse {verified=" + Verified + ", ibAuthCookie="
                + IbAuthCookie + "}";
		}
	}

}