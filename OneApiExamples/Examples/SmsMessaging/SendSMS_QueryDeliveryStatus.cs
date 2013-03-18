using System;
using System.IO;
using log4net.Config;
using OneApi.Client.Impl;
using OneApi.Config;
using OneApi.Model;
using OneApi.Exceptions;

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
        private static string senderAddress = "";
        private static string message = "";
        private static string recipientAddress = "";

        public static void Execute()
        {
            // Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            // Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));


            // Initialize Configuration object 
            Configuration configuration = new Configuration(System.Configuration.ConfigurationManager.AppSettings.Get("Username"), 
                                                            System.Configuration.ConfigurationManager.AppSettings.Get("Password"));
            SMSClient smsClient = new SMSClient(configuration);
            // ----------------------------------------------------------------------------------------------------

            // example:prepare-message-without-notify-url
            SMSRequest smsRequest = new SMSRequest(senderAddress, message, recipientAddress);
            // ----------------------------------------------------------------------------------------------------

            // example:send-message
            // Store request id because we can later query for the delivery status with it:
            SendMessageResult sendMessageResult = smsClient.SmsMessagingClient.SendSMS(smsRequest);
            // ----------------------------------------------------------------------------------------------------

            // Few seconds later we can check for the sending status   
            System.Threading.Thread.Sleep(10000);

            // example:query-for-delivery-status
            DeliveryInfoList deliveryInfoList = smsClient.SmsMessagingClient.QueryDeliveryStatus(senderAddress, sendMessageResult.ClientCorrelator);
            string deliveryStatus = deliveryInfoList.DeliveryInfos[0].DeliveryStatus;
            // ----------------------------------------------------------------------------------------------------
            Console.WriteLine(deliveryStatus);

        }
    }
}