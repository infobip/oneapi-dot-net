using System;
using System.IO;
using log4net.Config;
using OneApi.Client.Impl;
using OneApi.Config;
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
      *  3.) Open 'Examples.SendSMS_QueryDeliveryStatus' class to edit where you should populate the following fields: 
      *		'senderAddress'
      *		'message' 
      *		'recipientAddress'	
      *
      *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
      *      There you will enter the appropriate example number in the console and press 'Enter' key 
      *      on which the result will be displayed in the Console.      
      **/

    public class SendSMS_QueryDeliveryStatus
    {
        private static string username = System.Configuration.ConfigurationManager.AppSettings.Get("Username");
        private static string password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
        private static string senderAddress = "";
        private static string message = "";
        private static string recipientAddress = "";

        public static void Execute()
        {
            // Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            // Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));

            // example:initialize-sms-client
            // Initialize Configuration object
            Configuration configuration = new Configuration(username, password);

            // Initialize SMSClient using the Configuration object
            SMSClient smsClient = new SMSClient(configuration);
            // ----------------------------------------------------------------------------------------------------

            // example:prepare-message-without-notify-url
            // Prepare Message Without Notify URL
            SMSRequest smsRequest = new SMSRequest(senderAddress, message, recipientAddress);
            // ----------------------------------------------------------------------------------------------------

            // example:send-message
            // Send Message
            // Store request id because we can later query for the delivery status with it:
            SendMessageResult sendMessageResult = smsClient.SmsMessagingClient.SendSMS(smsRequest);
            // ----------------------------------------------------------------------------------------------------

            // example:send-message-client-correlator
            // The client correlator is a unique identifier of this api call
            string clientCorrelator = sendMessageResult.ClientCorrelator;
            // ----------------------------------------------------------------------------------------------------

            // Few seconds later we can check for the sending status   
            System.Threading.Thread.Sleep(10000);

            // example:query-for-delivery-status
            // Query for Delivery Status
            DeliveryInfoList deliveryInfoList = smsClient.SmsMessagingClient.QueryDeliveryStatus(senderAddress, clientCorrelator);
            string deliveryStatus = deliveryInfoList.DeliveryInfos[0].DeliveryStatus; 
           
            Console.WriteLine(deliveryStatus);
            // ----------------------------------------------------------------------------------------------------
        }
    }
}