namespace OneApi.Model
{
	public class LoginResponse
	{
        public bool Verified { get; set; }
        public string IbAuthCookie { get; set; }

        public LoginResponse()
        {
        }
		
		public override string ToString()
		{
            return "LoginResponse {verified=" + Verified + ", ibAuthCookie="
                + IbAuthCookie + "}";
		}
	}
}