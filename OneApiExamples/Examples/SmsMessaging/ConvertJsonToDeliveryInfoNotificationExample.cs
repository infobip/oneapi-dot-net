using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

    public class ConvertJsonToDeliveryInfoNotificationExample
	{
        private const string JSON = "{\"deliveryInfoNotification\":{\"deliveryInfo\":{\"address\":\"38454234234\",\"deliveryStatus\":\"DeliveredToTerminal\"},\"callbackData\":\"\"}}";

        public static void Execute()
        {
            Configuration configuration = new Configuration();
            SMSClient smsClient = new SMSClient(configuration);

            DeliveryInfoNotification deliveryInfoNotification = smsClient.SmsMessagingClient.ConvertJsonToDeliveryInfoNotification(JSON);
            Console.WriteLine("Delivery Info Notification: " + deliveryInfoNotification);   
        }
	}

}