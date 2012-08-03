using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Listeners;
using OneApi.Model;

namespace OneApi.Examples.Hlr
{

    public class QueryHLRAsyncExample : ExampleBase
	{

        private static string address = "";
        private static string notifyUrl = ""; //e.g. "http://127.0.0.1:3002/" 3002=Default port for 'HLR Notifications' server simulator

        public static void Execute(bool isInputConfigData)
		{
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;

			SMSClient smsClient = new SMSClient(configuration);

            //Login user
            LoginResponse loginResponse = smsClient.CustomerProfileClient.Login();
            if (loginResponse.Verified == false)
            {
                Console.WriteLine("User is not verified!");
                return;
            }

            smsClient.HlrClient.AddPushHlrNotificationsListener(new HLRNotificationsListener(OnHLRReceived));

            smsClient.HlrClient.QueryHLRAsync(address, notifyUrl);
            Console.WriteLine("Async HLR request sent successfully.");
		}

        private static void OnHLRReceived(RoamingNotification roamingNotification)
        {
            Console.WriteLine("HLR: " + roamingNotification);
        }
	}

}