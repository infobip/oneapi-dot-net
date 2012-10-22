using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

    public class QueryDeliveryStatusExample 
	{
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string senderAddress = "";
        private static string requestId = "";

		public static void Execute() 
		{
            Configuration configuration = new Configuration(username, password);   
			SMSClient smsClient = new SMSClient(configuration);

            DeliveryInfoList deliveryInfoList = smsClient.SmsMessagingClient.QueryDeliveryStatus(senderAddress, requestId);
            Console.WriteLine("Delivery Infos: " + string.Join("Delivery Info: ", deliveryInfoList.DeliveryInfos));   
		}
	}

}