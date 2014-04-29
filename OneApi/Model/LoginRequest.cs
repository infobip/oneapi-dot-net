using Newtonsoft.Json;
using System.ComponentModel;

namespace OneApi.Model
{
    public class LoginRequest
    {
        private string username;
        private string password;

        public LoginRequest()
        {
        }

        public LoginRequest(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        [DisplayName("username")]
        [JsonProperty("username")]
        public virtual string Username
        {
            get
            {
                return username;
            }
            set
            {
                this.username = value;
            }
        }

        [DisplayName("password")]
        [JsonProperty("password")]
        public virtual string Password
        {
            get
            {
                return password;
            }
            set
            {
                this.password = value;
            }
        }
    }
}
