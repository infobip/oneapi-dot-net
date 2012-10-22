using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

    public class RemoveInboundMessagesNotificationsSubscriptionExample 
	{
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string subscriptionId = "";

        public static void Execute()
		{
            Configuration configuration = new Configuration(username, password);  
			SMSClient smsClient = new SMSClient(configuration);

            smsClient.SmsMessagingClient.RemoveInboundMessagesNotificationsSubscription(subscriptionId);
            Console.WriteLine("Subscription canceled.");      
		}   
	}

}