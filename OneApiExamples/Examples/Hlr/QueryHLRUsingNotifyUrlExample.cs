using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Listeners;
using OneApi.Model;

namespace OneApi.Examples.Hlr
{

    public class QueryHLRUsingNotifyUrlExample 
	{
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string address = "";
        private static string notifyUrl = ""; //e.g. "http://127.0.0.1:3002/" 3002=Default port for 'HLR Notifications' server simulator

        public static void Execute()
		{
            Configuration configuration = new Configuration(username, password);   
			SMSClient smsClient = new SMSClient(configuration);

            smsClient.HlrClient.AddPushHLRNotificationsListener(new HLRNotificationsListener(roamingNotification => {
                Console.WriteLine("HLR: " + roamingNotification);
            }));

            smsClient.HlrClient.QueryHLR(address, notifyUrl);
            Console.WriteLine("HLR request sent successfully.");
		} 
	}

}