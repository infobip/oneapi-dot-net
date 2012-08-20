using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.Hlr
{

    public class GetHLRDeliveryNotificationsSubscriptionsExample : ExampleBase
	{

        private static string subscriptionId = "";

        public static void Execute()
		{
            Configuration configuration = new Configuration(username, password);                 
			SMSClient smsClient = new SMSClient(configuration);

            //Login user
            LoginResponse loginResponse = smsClient.CustomerProfileClient.Login();
            if (loginResponse.Verified == false)
            {
                Console.WriteLine("User is not verified!");
                return;
            }

            DeliveryReportSubscription[] deliveryReportSubscriptions = smsClient.HlrClient.GetHLRDeliveryNotificationsSubscriptionsById(subscriptionId);
            Console.WriteLine("HLR Subscriptions: " + string.Join("HLR Subscription: ", (Object[])deliveryReportSubscriptions)); 
		}  
	}

}