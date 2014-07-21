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
      *  1.) Download 'Infobip C# library' - available at www.github.com/infobip
      *
      *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project    
      *
      *  3.) Open 'Examples.SendSMS_GetDeliveryReportsByRequestId' class to edit where you should populate the following fields: 
      *		'senderAddress' 
      *	    'message'
      *		'recipientAddress'	
      *		'requestId'
      *
      *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
      *      There you will enter the appropriate example number in the console and press 'Enter' key 
      *      on which the result will be displayed in the Console.
      *       
      *  Note: 'Delivery Reports' are retrieved default every 5000 milisecons (5 seconds). Retrieving interval can be changed
      *  by setting the 'Configuration' property 'DlrRetrievingInterval'.
      **/

    public class SendSMS_GetDeliveryReportsByRequestId
    {
        private static string senderAddress = "";
        private static string message = "";
        private static string recipientAddress = "";
        private static string requestId = "";

        public static void Execute()
        {

            // Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            // Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));

            // Initialize Configuration object 
            Configuration configuration = new Configuration(System.Configuration.ConfigurationManager.AppSettings.Get("Username"),
                                                            System.Configuration.ConfigurationManager.AppSettings.Get("Password"));

            // Initialize SMSClient using the Configuration object
            SMSClient smsClient = new SMSClient(configuration);

            // Send SMS 
            smsClient.SmsMessagingClient.SendSMS(new SMSRequest(senderAddress, message, recipientAddress));

            // Wait for 30 seconds to give enought time for the message to be delivered
            System.Threading.Thread.Sleep(30000);

            // Get 'Delivery Reports'
            DeliveryReportList deliveryReportList = smsClient.SmsMessagingClient.GetDeliveryReportsByRequestId(requestId);
            Console.WriteLine(deliveryReportList);

        }
    }
}