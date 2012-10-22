using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Listeners;

namespace OneApi.Examples.Async
{

    public class QueryDeliveryStatusAsyncExample 
    {
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string senderAddress = "";
        private static string requestId = "";

        public static void Execute()
        {
            Configuration configuration = new Configuration(username, password);      
            SMSClient smsClient = new SMSClient(configuration);

            smsClient.SmsMessagingClient.QueryDeliveryStatusAsync(senderAddress, requestId, (deliveryInfoList, e) =>
            {
                if (e == null)
                {
                    Console.WriteLine("Delivery Infos: " + deliveryInfoList);  
                } else {
                    Console.WriteLine("Exception: " + e.Message); 
                }    
            });  

        }
    }
}