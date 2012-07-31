using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

    public class QueryDeliveryStatusExample : ExampleBase
	{

        private static string senderAddress = "";
        private static string requestId = "";

		public static void Execute(bool isInputConfigData) 
		{
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;

			SMSClient smsClient = new SMSClient(configuration);

            DeliveryInfoList deliveryInfoList = smsClient.SmsMessagingClient.QueryDeliveryStatus(senderAddress, requestId);
            Console.WriteLine("Delivery Infos: " + string.Join("Delivery Info: ", deliveryInfoList.DeliveryInfos));   
		}
	}

}