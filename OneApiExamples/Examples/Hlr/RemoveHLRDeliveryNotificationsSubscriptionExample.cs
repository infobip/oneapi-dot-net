using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.Hlr
{

	public class RemoveHLRDeliveryNotificationsSubscriptionExample : ExampleBase
	{

        private static string subscriptionId = "";

        public static void Execute()
		{
            Configuration configuration = new Configuration(username, password);   	
            SMSClient smsClient = new SMSClient(configuration);

            smsClient.HlrClient.RemoveHLRDeliveryNotificationsSubscription(subscriptionId);
            Console.WriteLine("Subscription canceled.");
           
        }
	}

}