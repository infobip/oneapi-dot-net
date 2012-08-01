using System.Text;
using System.Net;
using System.Web;
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

        public CustomerProfileClientImpl(Configuration configuration): base(configuration)
        {
        }

        public CustomerProfile GetCustomerProfile() {	   
            HttpWebResponse response = ExecuteGet(AppendMessagingBaseUrl(CUSTOMER_PROFILE_URL_BASE));
            return Deserialize<CustomerProfile>(response, RESPONSE_CODE_200_OK);
	    }
    }
}