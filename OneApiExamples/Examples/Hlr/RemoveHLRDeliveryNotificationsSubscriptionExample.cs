using System;
using OneApi.Config;
using OneApi.Client.Impl;

namespace OneApi.Examples.Hlr
{

	public class RemoveHLRDeliveryNotificationsSubscriptionExample : ExampleBase
	{

        private static string subscriptionId = "";

        public static void Execute(bool isInputConfigData)
		{
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;
			
            SMSClient smsClient = new SMSClient(configuration);
            
            smsClient.HlrClient.RemoveHLRDeliveryNotificationsSubscription(subscriptionId);

            Console.WriteLine("Subscription canceled.");
           
        }
	}

}