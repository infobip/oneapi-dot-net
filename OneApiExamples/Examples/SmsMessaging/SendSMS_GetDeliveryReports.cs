using System;
using System.IO;
using log4net.Config;
using OneApi.Client.Impl;
using OneApi.Config;
using OneApi.Model;
using System.Collections.Generic;

namespace OneApi.Examples.SmsMessaging
{

    /**
      * To run this example follow these 4 steps:
      *
      *  1.) Download 'Parseco C# library' - available at www.github.com/parseco    
      *
      *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project    
      *
      *  3.) Open 'Examples.SendSMS_GetDeliveryReports' class to edit where you should populate the following fields: 
      *		'senderAddress'
      *		'message' 
      *		'recipientAddress'	
      *
      *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
      *      There you will enter the appropriate example number in the console and press 'Enter' key 
      *      on which the result will be displayed in the Console.      
      **/

    public class SendSMS_GetDeliveryReports
    {
        private static string username = System.Configuration.ConfigurationManager.AppSettings.Get("Username");
        private static string password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
        private static string senderAddress = "mirko";
        private static string message = "ovo je poruka";
        private static List<string> recipientAddress;

        public static void Execute()
        {
            // Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            // Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));


            // Initialize Configuration object 
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = "http://192.168.10.18:9130";

            // Initialize SMSClient using the Configuration object
            SMSClient smsClient = new SMSClient(configuration);
                        
            string prefix = "38598";
            Random r = new Random();
            for (int i = 0; i < 10000; i++)
            {
                recipientAddress = new List<string>();
                int numNumbers = r.Next(5, 20);
                for (int j = 0; j < numNumbers; j++)
                {
                    recipientAddress.Add(prefix + r.Next(1000000, 9999999).ToString());
                }

                SMSRequest eeee = new SMSRequest(senderAddress, message, recipientAddress.ToArray());
                eeee.NotifyURL = "http://ria.infobip.com/status/oneapi/";

                var aaaa = smsClient.SmsMessagingClient.SendSMS(eeee);
            }

            //SMSRequest eeee = new SMSRequest(senderAddress, message, recipientAddress);
            //eeee.NotifyURL = "http://ria.infobip.com/status/oneapi/";

            // Send SMS 
            //var aaaa = smsClient.SmsMessagingClient.SendSMS(eeee);  //new SMSRequest(senderAddress, message, recipientAddress));

            // Wait for 30 seconds to give enought time for the message to be delivered
            //System.Threading.Thread.Sleep(30000);

            // Get 'Delivery Reports'
            //DeliveryReportList deliveryReportList = smsClient.SmsMessagingClient.GetDeliveryReports();
            //Console.WriteLine(deliveryReportList);
        }
    }
}