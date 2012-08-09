using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.Hlr
{

    public class SubscribeToHLRDeliveryNotificationsExample : ExampleBase
	{

        private static string notifyUrl = ""; //e.g. "http://127.0.0.1:3002/" 3002=Default port for 'HLR Notifications' server simulator

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

            string subscriptionId = smsClient.HlrClient.SubscribeToHLRDeliveryNotifications(new SubscribeToHLRDeliveryNotificationsRequest(notifyUrl));
            Console.WriteLine("Subscription Id: " + subscriptionId); 
		}    
	}

}