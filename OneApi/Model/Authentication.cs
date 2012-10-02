using Newtonsoft.Json;

namespace OneApi.Model
{
	public class Authentication
	{
		public enum AuthType
		{
            BASIC,
            IBSSO,
			OAUTH
		}

		public Authentication() : base()
		{
            Type = AuthType.BASIC;
		}

		/// <summary>
        /// Initialize 'BASIC' Authentication (to use 'IBSSO' Authentication you need to call 'CustomerProfileClient.Login()' method after client initialization)</summary>
		/// <param name="username"> </param>
		/// <param name="password"> </param>
		public Authentication(string username, string password) : this()
		{  
			Username = username;
			Password = password;
		}

		/// <summary>
		/// Initialize 'OAUTH' Authentication </summary>
		/// <param name="accessToken"> </param>
		public Authentication(string accessToken)
		{
			AccessToken = accessToken;
			Type = AuthType.OAUTH;
		}

		/// <summary>
		/// Authentication type </summary>
		/// <returns> AuthType </returns>
        [JsonProperty(PropertyName = "type")]
        public AuthType Type;

		/// <summary>
        /// 'BASIC' Authentication user name </summary>
		/// <returns> String </returns>
        [JsonProperty(PropertyName = "username")]
        public string Username;

		/// <summary>
        /// 'BASIC' Authentication password </summary>
		/// <returns> String </returns>
        [JsonProperty(PropertyName = "password")]
        public string Password;

        /// <summary>
        /// 'IBSSO' Authentication token </summary>
        /// <returns> String </returns>
        [JsonIgnore]
        public string IbssoToken;

		/// <summary>
        /// 'OAUTH' Authentication Access Token </summary>
		/// <returns> String </returns>
        [JsonProperty(PropertyName = "accessToken")]
        public string AccessToken;
	}
}