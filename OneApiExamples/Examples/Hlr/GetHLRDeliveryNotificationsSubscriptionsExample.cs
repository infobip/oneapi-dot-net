using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.Hlr
{

    public class GetHLRDeliveryNotificationsSubscriptionsExample : ExampleBase
	{

        private static string subscriptionId = "";

        public static void Execute(bool isInputConfigData)
		{
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;
           
			SMSClient smsClient = new SMSClient(configuration);

            DeliveryReportSubscription[] deliveryReportSubscriptions = smsClient.HlrClient.GetHLRDeliveryNotificationsSubscriptionsById(subscriptionId);
            Console.WriteLine("HLR Subscriptions: " + string.Join("HLR Subscription: ", (Object[])deliveryReportSubscriptions)); 
		}  
	}

}