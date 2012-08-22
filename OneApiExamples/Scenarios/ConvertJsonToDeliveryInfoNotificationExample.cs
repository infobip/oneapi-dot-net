using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Scenarios
{

    public class ConvertJsonToDeliveryInfoNotificationExample
	{
        // Pushed 'Delivery Info Notification' JSON example
        private const string JSON = "{\"deliveryInfoNotification\":{\"deliveryInfo\":{\"address\":\"38454234234\",\"deliveryStatus\":\"DeliveredToTerminal\"},\"callbackData\":\"\"}}";

        public static void Execute()
        {
            Configuration configuration = new Configuration();
            SMSClient smsClient = new SMSClient(configuration);

            // example:on-delivery-notification
            DeliveryInfoNotification deliveryInfoNotification = smsClient.SmsMessagingClient.ConvertJsonToDeliveryInfoNotification(JSON);
            // ----------------------------------------------------------------------------------------------------
            Console.WriteLine(deliveryInfoNotification);   
        }
	}

}