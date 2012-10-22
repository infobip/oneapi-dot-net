using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;


namespace OneApi.Examples.SmsMessaging
{
    public class GetDeliveryReportsExample 
    {
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";

        public static void Execute() 
        {
            Configuration configuration = new Configuration(username, password); 
            SMSClient smsClient = new SMSClient(configuration);

            DeliveryReportList deliveryReportList = smsClient.SmsMessagingClient.GetDeliveryReports();
            Console.WriteLine("Delivery Reports: " + deliveryReportList); 
        }    
    }

}