using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

    public class GetDeliveryNotificationsSubscriptionsExample 
	{
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";

		public static void Execute() 
		{
            Configuration configuration = new Configuration(username, password);   
			SMSClient smsClient = new SMSClient(configuration);

            DeliveryReportSubscription[] deliveryReportSubscriptions = smsClient.SmsMessagingClient.GetDeliveryNotificationsSubscriptions();
            Console.WriteLine("Delivery Info Subscriptions: " + string.Join(",", (Object[])deliveryReportSubscriptions));    
		}
	}

}