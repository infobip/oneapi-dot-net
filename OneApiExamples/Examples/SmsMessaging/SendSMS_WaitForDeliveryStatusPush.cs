using System;
using System.IO;
using log4net.Config;
using OneApi.Client.Impl;
using OneApi.Config;
using OneApi.Listeners;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

    /**
      * To run this example follow these 4 steps:
      *
      *  1.) Download 'Parseco C# library' - available at www.github.com/parseco    
      *
      *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project    
      *
      *  3.) Open 'Examples.SendSMS_WaitForDeliveryStatusPush' class to edit where you should populate the following fields: 
      *		'senderAddress'     
     *		'notifyUrl'
      *		'message'                   
      *		'recipientAddress'   
      *
      *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
      *      There you will enter the appropriate example number in the console and press 'Enter' key 
      *      on which the result will be displayed in the Console.
      *
      *  Note: 'Delivery Status Notifications' push server is started automatically by adding 'DeliveryStatusNotificationsListener'
      *  using the 'AddPushDeliveryStatusNotificationListener' method. Default server port is 3000 and it can be changed by set the 
      *  'Configuration' property 'DlrStatusPushServerPort'. 
      *  Used port should match the one used in the 'SMSRequest' 'NotifyUrl' parameter.
      **/

    public class SendSMS_WaitForDeliveryStatusPush
    {
        private static string username = System.Configuration.ConfigurationManager.AppSettings.Get("Username");
        private static string password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
        private static string senderAddress = "";
        private static string message = "";
        private static string recipientAddress = "";
        private static string notifyUrl = ""; //e.g. "http://127.0.0.1:3000/" 3000=Default port for 'Delivery Info Notifications' server simulator

        public static void Execute()
        {
            // Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            // Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));


            // Initialize Configuration object 
            Configuration configuration = new Configuration(username, password);

            // Initialize SMSClient using the Configuration object
            SMSClient smsClient = new SMSClient(configuration);

            // Add listener(start push server and wait for the 'Delivery Info Notifications')    
            smsClient.SmsMessagingClient.AddPushDeliveryStatusNotificationsListener(new DeliveryStatusNotificationsListener((deliveryInfoNotification) =>
            {                
                // Handle pushed 'Delivery Info Notification'
                if (deliveryInfoNotification != null)
                {
                    // example:on-delivery-notification
                    Console.WriteLine("status: " + deliveryInfoNotification.DeliveryInfo.DeliveryStatus);
                    Console.WriteLine("address: " + deliveryInfoNotification.DeliveryInfo.Address);
                    Console.WriteLine("messageId: " + deliveryInfoNotification.DeliveryInfo.MessageId);
                    Console.WriteLine("clientCorrelator: " + deliveryInfoNotification.DeliveryInfo.ClientCorrelator);
                    Console.WriteLine("callback data: " + deliveryInfoNotification.CallbackData);
                    // ----------------------------------------------------------------------------------------------------
                }
            }));

            // example:prepare-message-with-notify-url
            // Prepare Message With Notify URL
            SMSRequest smsRequest = new SMSRequest(senderAddress, message, recipientAddress);
            // The url where the delivery notification will be pushed:
            smsRequest.NotifyURL = notifyUrl;
            // ----------------------------------------------------------------------------------------------------

            // Send SMS 
            smsClient.SmsMessagingClient.SendSMS(smsRequest);

            // Wait 30 seconds for 'Delivery Info Notification' push-es before closing the server connection 
            System.Threading.Thread.Sleep(30000);

            // Remove 'Delivery Info Notifications' push listeners and stop the server
            smsClient.SmsMessagingClient.RemovePushDeliveryStatusNotificationsListeners();

        }
    }
}