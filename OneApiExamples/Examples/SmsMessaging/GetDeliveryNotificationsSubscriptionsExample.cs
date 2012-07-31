using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

    public class GetDeliveryNotificationsSubscriptionsExample : ExampleBase
	{

		public static void Execute(bool isInputConfigData) 
		{
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;

			SMSClient smsClient = new SMSClient(configuration);

            DeliveryReportSubscription[] deliveryReportSubscriptions = smsClient.SmsMessagingClient.GetDeliveryNotificationsSubscriptions();
            Console.WriteLine("Delivery Info Subscriptions: " + string.Join(",", (Object[])deliveryReportSubscriptions));    
		}
	}

}