using OneApi.Config;

namespace OneApi.Client.Impl
{

	public class SMSClient
	{
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
			smsMessagingClient = new SMSMessagingClientImpl(configuration);
			hlrClient = new HLRClientImpl(configuration);
		}

		//*************************SMSClient public***********************************************************************************************************************************************
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
	}
}