using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

    public class GetDeliveryNotificationsSubscriptionsExample : ExampleBase
	{

		public static void Execute() 
		{
            Configuration configuration = new Configuration(username, password);   
			SMSClient smsClient = new SMSClient(configuration);

            LoginResponse loginResponse = smsClient.CustomerProfileClient.Login();
            if (loginResponse.Verified == false)
            {
                Console.WriteLine("User is not verified!");
                return;
            }

            DeliveryReportSubscription[] deliveryReportSubscriptions = smsClient.SmsMessagingClient.GetDeliveryNotificationsSubscriptions();
            Console.WriteLine("Delivery Info Subscriptions: " + string.Join(",", (Object[])deliveryReportSubscriptions));    
		}
	}

}