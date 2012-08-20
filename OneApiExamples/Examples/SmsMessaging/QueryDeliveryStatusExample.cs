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

            DeliveryInfoList deliveryInfoList = smsClient.SmsMessagingClient.QueryDeliveryStatus(senderAddress, requestId);
            Console.WriteLine("Delivery Infos: " + string.Join("Delivery Info: ", deliveryInfoList.DeliveryInfos));   
		}
	}

}