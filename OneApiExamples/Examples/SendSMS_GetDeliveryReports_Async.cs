using System;
using System.IO;
using log4net.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Config;
using OneApi.Exceptions;

namespace OneApi.Scenarios
{

    /**
      * To run this example follow these 4 steps:
      *
      *  1.) Download 'Parseco C# library' - available at www.github.com/parseco   or   www.parseco.com/apis    
      *
      *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project    
      *
      *  3.) Open 'Scenarios.SendSMS_GetDeliveryReports_Async' class to edit where you should populate the following fields: 
      *		'senderAddress'    'username'
      *		'message'          'password' 
      *		'recipientAddress'	
      *
      *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
      *      There you will enter the appropriate example number in the console and press 'Enter' key 
      *      on which the result will be displayed in the Console.      
      **/

    public class SendSMS_GetDeliveryReports_Async
    {
        private static string username = "parseco";
        private static string password = "Parseco+1";
        private static string senderAddress = "Sender";
        private static string message = "Hi";
        private static string recipientAddress = "385997701356";

        public static void Execute()
        {
            // Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            // Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));


            // Initialize Configuration object 
            Configuration configuration = new Configuration(username, password);

            // Initialize SMSClient using the Configuration object
            SMSClient smsClient = new SMSClient(configuration);

            try
            {
                // Login sms client
                LoginResponse loginResponse = smsClient.CustomerProfileClient.Login();
                if (loginResponse.Verified == false)
                {
                    Console.WriteLine("User is not verified!");
                    return;
                }
            }
            catch (RequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            // Send SMS 
            smsClient.SmsMessagingClient.SendSMSAsync(new SMSRequest(senderAddress, message, recipientAddress), (requestId, e) =>
            {
                if (e == null)
                {
                    // Get 'Delivery Reports'
                    smsClient.SmsMessagingClient.GetDeliveryReportsAsync((deliveryReportList, e1) =>
                    {
                        if (e1 == null)
                        {
                            Console.WriteLine(deliveryReportList);

                            // Logout sms client
                            smsClient.CustomerProfileClient.Logout();
                        }
                        else
                        {
                            Console.WriteLine(e1.Message);
                        }
                    });
                }
                else
                {
                    Console.WriteLine(e.Message);
                }
            });
        }
    }
}