using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Listeners;

namespace OneApi.Examples.SmsMessaging
{

    public class DeliveryReportsRetrieverExample 
	{
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";

		public static void Execute()
		{  
            Configuration configuration = new Configuration(username, password);    
			SMSClient smsClient = new SMSClient(configuration);

            smsClient.SmsMessagingClient.AddPullDeliveryReportListener(new DeliveryReportListener((deliveryReportList, e) =>
            {
                //Handle pulled Delivery Reports
                if (e == null)
                {
                    Console.WriteLine("Delivery Reports: " + deliveryReportList);
                }
                else
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }));

            //Stop the Delivery Reports retriever and release listeners
            //smsClient.SmsMessagingClient.RemovePullDeliveryReportListeners();
		}
	}

}