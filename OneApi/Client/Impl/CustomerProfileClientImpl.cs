using System.Text;
using System.Net;
using System.Web;
using System;
using System.Collections.Generic;
using OneApi.Listeners;
using OneApi.Config;
using OneApi.Exceptions;
using OneApi.Model;

namespace OneApi.Client.Impl
{

    public class CustomerProfileClientImpl : OneAPIBaseClientImpl, CustomerProfileClient
    {
        private const string CUSTOMER_PROFILE_URL_BASE = "/customerProfile";
        private Action<LoginResponse> onLogin;
        private Action onLogout;

        public CustomerProfileClientImpl(Configuration configuration, Action<LoginResponse> onLogin, Action onLogout) : base(configuration)      
        {
            this.onLogin = onLogin;
            this.onLogout = onLogout;
        }

        /// <summary>
        /// Get configured user customer profile </summary>
        /// <returns> CustomerProfile </returns>
        public CustomerProfile GetCustomerProfile()
        {
            HttpWebResponse response = ExecuteGet(AppendMessagingBaseUrl(CUSTOMER_PROFILE_URL_BASE));
            return Deserialize<CustomerProfile>(response, RESPONSE_CODE_200_OK);
        }

        /// <summary>
        /// User Login </summary>
        /// <returns> LoginResponse </returns>
        public LoginResponse Login() {
		    LoginRequest loginRequest = new LoginRequest(Configuration.Authentication.Username, Configuration.Authentication.Password);	
		    HttpWebResponse response = ExecutePost(AppendMessagingBaseUrl(CUSTOMER_PROFILE_URL_BASE + "/login"), loginRequest);
            LoginResponse loginResponse = Deserialize<LoginResponse>(response, RESPONSE_CODE_200_OK, "login");
            
            onLogin(loginResponse);
            return loginResponse;
	    }

        /// <summary>
        /// User Logout </summary>
	    public void Logout() {	  
            HttpWebResponse response = ExecutePost(AppendMessagingBaseUrl(CUSTOMER_PROFILE_URL_BASE + "/logout"));
            validateResponse(response, RESPONSE_CODE_204_NO_CONTENT);
            onLogout();
	    }
    }
}