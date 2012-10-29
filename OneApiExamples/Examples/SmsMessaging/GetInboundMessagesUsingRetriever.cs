using System;
using log4net.Config;
using System.IO;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Exceptions;
using OneApi.Listeners;

namespace OneApi.Examples.SmsMessaging
{

    /**
     * To run this example follow these 4 steps:
     *
     *  1.) Download 'Parseco C# library' - available at www.github.com/parseco
     *
     *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project 
     *
     *  3.) Open 'Examples.GetInboundMessagesUsingRetriever' class to edit where you should populate the following fields: 
     *		'username' 
     *		'password'  
     *
     *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
     *       There you will enter the appropriate example number in the console and press 'Enter' key 
     *       on which the result will be displayed in the Console.
     *       
     *  Note: 'Inbound Messages' are retrieved default every 5000 milisecons (5 seconds). Retrieving interval can be changed
     *        by setting the 'Configuration' property 'InboundMessagesRetrievingInterval'.
     **/

    public class GetInboundMessagesUsingRetriever
    {
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";

        public static void Execute()
        {
            // Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            // Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));


            // Initialize Configuration object 
            Configuration configuration = new Configuration(username, password);

            // Initialize SMSClient using the Configuration object
            SMSClient smsClient = new SMSClient(configuration);

            // Add listener(start retriever and pull 'Inbound Messages')    
            smsClient.SmsMessagingClient.AddPullInboundMessageListener(new InboundMessageListener((smsMessageList, e) =>
            {
                // Handle pulled 'Inbound Messages'
                if (e == null)
                {
                    Console.WriteLine(smsMessageList);
                }
                else
                {
                    Console.WriteLine(e.Message);
                }
            }));

            // Wait 30 seconds for the 'Inbound Messages' before stop the retriever  
            System.Threading.Thread.Sleep(30000);

            // Remove 'Inbound Messages' pull listeners and stop the retriever
            smsClient.SmsMessagingClient.RemovePullInboundMessageListeners();

        }
    }
}
