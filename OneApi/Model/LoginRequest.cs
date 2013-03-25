using System.ComponentModel;

namespace OneApi.Model
{
    public class LoginRequest
    {
        [DisplayName("username")]
        public string Username { get; set; }

        [DisplayName("password")]
        public string Password { get; set; }

        public LoginRequest()
        {
        }

        public LoginRequest(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
