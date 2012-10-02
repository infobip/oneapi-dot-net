using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

	public class SubscribeToInboundMessagesNotificationsExample : ExampleBase
	{

        private static string destinationAddress = "";
        private static string notifyUrl = ""; //e.g. "http://127.0.0.1:3001/" 3001=Default port for 'Inbound Messages Notifications' server simulator
        private static string criteria = "";
        private static string notificationFormat = "JSON"; 

		public static void Execute()
		{
            Configuration configuration = new Configuration(username, password);      
			SMSClient smsClient = new SMSClient(configuration);

            string subscriptionId = smsClient.SmsMessagingClient.SubscribeToInboundMessagesNotifications(new SubscribeToInboundMessagesRequest(destinationAddress, notifyUrl, criteria, notificationFormat, "", ""));
            Console.WriteLine("Subscription Id: " + subscriptionId); 
		}
	}

}