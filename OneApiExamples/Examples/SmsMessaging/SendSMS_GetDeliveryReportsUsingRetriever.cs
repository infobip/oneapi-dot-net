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
      *  3.) Open 'Examples.SendSMS_GetDeliveryReportsUsingRetriever' class to edit where you should populate the following fields: 
      *		'senderAddress' 'username' 
      *	    'message'       'password'
      *		'recipientAddress'	
      *
      *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
      *      There you will enter the appropriate example number in the console and press 'Enter' key 
      *      on which the result will be displayed in the Console.
      *       
      *  Note: 'Delivery Reports' are retrieved default every 5000 milisecons (5 seconds). Retrieving interval can be changed
      *  by setting the 'Configuration' property 'DlrRetrievingInterval'.
      **/

    public class SendSMS_GetDeliveryReportsUsingRetriever
    {
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string senderAddress = "";
        private static string message = "";
        private static string recipientAddress = "";

        public static void Execute()
        {
            // Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            // Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));


            // Initialize Configuration object 
            Configuration configuration = new Configuration(username, password);

            // Initialize SMSClient using the Configuration object
            SMSClient smsClient = new SMSClient(configuration);

            // Add listener(start retriever and pull 'Delivery Reports')  
            smsClient.SmsMessagingClient.AddPullDeliveryReportListener(new DeliveryReportListener((deliveryReportList, e) =>
            {
                //Handle pulled 'Delivery Reports'
                if (e == null)
                {
                    //TODO: update database
                    Console.WriteLine(deliveryReportList);
                }
                else
                {
                    Console.WriteLine(e.Message);
                }
            }));

            // Send SMS 
            smsClient.SmsMessagingClient.SendSMS(new SMSRequest(senderAddress, message, recipientAddress));

            // Wait 30 seconds for the 'Delivery Reports' before stop the retriever  
            System.Threading.Thread.Sleep(30000);

            // Remove 'Delivery Reports' pull listeners and stop the retriever
            smsClient.SmsMessagingClient.RemovePullDeliveryReportListeners();

        }
    }
}