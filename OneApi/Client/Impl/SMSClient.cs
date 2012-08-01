using OneApi.Config;
using OneApi.Exceptions;
using OneApi.Model;

namespace OneApi.Client.Impl
{

	public class SMSClient
	{
        private CustomerProfileClient customerProfileClient  = null;
		private SMSMessagingClient smsMessagingClient = null;
		private HLRClient hlrClient = null;
		private Configuration configuration = null;
		
		//*************************SMSClient initialization***********************************************************************************************************************************************
		/// <summary>
		/// Initialize SMS client using specified 'configuration' parameter </summary>
		/// <param name="configuration"> - parameter containing OneAPI configuration data </param>
		public SMSClient(Configuration configuration)
		{
			this.configuration = configuration;

			//Initialize Clients   
            customerProfileClient = new CustomerProfileClientImpl(configuration);
			smsMessagingClient = new SMSMessagingClientImpl(configuration);
			hlrClient = new HLRClientImpl(configuration);
		}

        /// <summary>
        /// Customer Profile client </summary>
        /// <returns> CustomerProfileClient </returns>
        public CustomerProfileClient CustomerProfileClient
        {
            get
            {
                return customerProfileClient;
            }
        }
        
        /// <summary>
		/// SMS Messaging client </summary>
		/// <returns> SMSMessagingClient </returns>
		public SMSMessagingClient SmsMessagingClient
		{
           get
           {
               return smsMessagingClient;	
           }   
		}

		/// <summary>
		/// DHLR client </summary>
        /// <returns> HLRClient </returns>
        public HLRClient HlrClient
		{
           get
           {
                return hlrClient;
           }      
		}

        /// <summary>
        /// Validate configured data and connection to the API </summary>
        /// <returns>ValidateClientResponse </returns>
        public ValidateClientResponse IsValid()
        {
            ValidateClientResponse validateClientResponse = new ValidateClientResponse();

            try
            {
                //Dummy call to check configured data and connection to the api
                customerProfileClient.GetCustomerProfile();
            }
            catch (RequestException e)
            {
                validateClientResponse.IsValid = false;
                validateClientResponse.ErrorMessage = e.Message;
            }

            return validateClientResponse;
        }
	}
}