using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

	public class SubscribeToDeliveryStatusNotificationsExample : ExampleBase
	{

        private static string senderAddress = "";
        private static string notifyUrl = ""; //e.g. "http://127.0.0.1:3000/" 3000=Default port for 'Delivery status Notifications' server simulator
        private static string criteria = "";

		public static void Execute(bool isInputConfigData)
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

            string subscriptionId = smsClient.SmsMessagingClient.SubscribeToDeliveryStatusNotifications(new SubscribeToDeliveryNotificationsRequest(senderAddress, notifyUrl, criteria, "", ""));
            Console.WriteLine("Subscription Id: " + subscriptionId); 
		}
	}

}