using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.Hlr
{

    public class GetHLRDeliveryNotificationsSubscriptionsExample 
	{
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string subscriptionId = "";

        public static void Execute()
		{
            Configuration configuration = new Configuration(username, password);                 
			SMSClient smsClient = new SMSClient(configuration);

            DeliveryReportSubscription[] deliveryReportSubscriptions = smsClient.HlrClient.GetHLRDeliveryNotificationsSubscriptionsById(subscriptionId);
            Console.WriteLine("HLR Subscriptions: " + string.Join("HLR Subscription: ", (Object[])deliveryReportSubscriptions)); 
		}  
	}

}