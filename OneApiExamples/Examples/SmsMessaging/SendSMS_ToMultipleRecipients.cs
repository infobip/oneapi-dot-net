using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using log4net.Config;
using System.IO;

namespace OneApi.Examples.SmsMessaging
{

    /**
    * To run this example follow these 4 steps:
    *
    *  1.) Download 'Parseco C# library' - available at www.github.com/parseco  
    *
    *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project    
    *
    *  3.) Open 'Examples.SendSMS_ToMultipleRecipients' class to edit where you should populate the following fields: 
    *		'senderAddress'    'username'
    *		'message'          'password' 
    *		'recipientAddress'	
    *
    *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
    *      There you will enter the appropriate example number in the console and press 'Enter' key 
    *      on which the result will be displayed in the Console.      
    **/

    public class SendSMS_ToMultipleRecipients
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

            string[] address = new string[2];
            address[0] = recipientAddress;
            address[1] = recipientAddress;

            SMSRequest smsRequest = new SMSRequest(senderAddress, message, address);

            string requestId = smsClient.SmsMessagingClient.SendSMS(smsRequest);
            Console.WriteLine("Request Id: " + requestId);
        }
    }
}