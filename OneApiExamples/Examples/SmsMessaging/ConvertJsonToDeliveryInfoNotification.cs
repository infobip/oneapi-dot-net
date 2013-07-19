using System;
using OneApi.Client.Impl;
using OneApi.Config;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{
    /**
    * To run this example follow these 4 steps:
    *
    *  1.) Download 'Infobip C# library' - available at www.github.com/infobip     
    *
    *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project 
    *
    *  3.) Open 'Examples.ConvertJsonToDeliveryInfoNotification' class 
    *  
    *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
    *       There you will enter the appropriate example number in the console and press 'Enter' key 
    *       on which the result will be displayed in the Console.
    *       
    **/

    public class ConvertJsonToDeliveryInfoNotification
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