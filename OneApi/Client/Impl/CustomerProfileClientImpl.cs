using System.Text;
using System.Net;
using System.Web;
using System;
using System.Collections.Generic;
using OneApi.Listeners;
using OneApi.Config;
using OneApi.Exceptions;
using OneApi.Model;
using org.infobip.oneapi.model;
using RestSharp;

namespace OneApi.Client.Impl
{

    public class CustomerProfileClientImpl : OneAPIBaseClientImpl, CustomerProfileClient
    {
        private const string CUSTOMER_PROFILE_URL_BASE = "/customerProfile";
        private Action<LoginResponse> onLogin;
        private Action onLogout;

        public CustomerProfileClientImpl(Configuration configuration, Action<LoginResponse> onLogin, Action onLogout)
            : base(configuration)
        {
            this.onLogin = onLogin;
            this.onLogout = onLogout;
        }

        /// <summary>
        /// User Login </summary>
        /// <returns> LoginResponse </returns>
        public LoginResponse Login()
        {
            LoginRequest loginRequest = new LoginRequest(Configuration.Authentication.Username, Configuration.Authentication.Password);
            RequestData requestData = new RequestData(CUSTOMER_PROFILE_URL_BASE + "/login", RESPONSE_CODE_200_OK, Method.POST, "login", loginRequest);
            LoginResponse loginResponse = ExecuteMethod<LoginResponse>(requestData);
            onLogin(loginResponse);
            return loginResponse;
        }

        /// <summary>
        /// User Logout </summary>
        public void Logout()
        {
            RequestData requestData = new RequestData(CUSTOMER_PROFILE_URL_BASE + "/logout", RESPONSE_CODE_204_NO_CONTENT, Method.POST);
            ExecuteMethod(requestData);
            onLogout();
        }

        /// <summary>
        /// Get logged user customer profile </summary>
        /// <returns> CustomerProfile </returns>
        public CustomerProfile GetCustomerProfile()
        {
            RequestData requestData = new RequestData(CUSTOMER_PROFILE_URL_BASE, RESPONSE_CODE_200_OK, Method.GET);
            return ExecuteMethod<CustomerProfile>(requestData);
        }

        /// <summary>
        /// Get logged user customer profiles list </summary>
        /// </summary>
        /// <returns> CustomerProfile[] </returns>
        public CustomerProfile[] GetCustomerProfiles()
        {
            RequestData requestData = new RequestData(CUSTOMER_PROFILE_URL_BASE + "/list", RESPONSE_CODE_200_OK, Method.GET);
            return ExecuteMethod<CustomerProfile[]>(requestData);
        }

        /// <summary>
        /// Get specific user customer profile by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> CustomerProfile </returns>
        public CustomerProfile GetCustomerProfileByUserId(int id)
        {
            StringBuilder urlBuilder = new StringBuilder(CUSTOMER_PROFILE_URL_BASE).Append("/");
            urlBuilder.Append(HttpUtility.UrlEncode(id.ToString()));

            RequestData requestData = new RequestData(urlBuilder.ToString(), RESPONSE_CODE_200_OK, Method.GET);
            return ExecuteMethod<CustomerProfile>(requestData);
        }

        /// <summary>
        /// Get logged user account balance </summary>
        /// </summary>
        /// <returns> AccountBalance </returns>
        public AccountBalance GetAccountBalance()
        {
            RequestData requestData = new RequestData(CUSTOMER_PROFILE_URL_BASE + "/balance", RESPONSE_CODE_200_OK, Method.GET);
            return ExecuteMethod<AccountBalance>(requestData);
        }
    }
}