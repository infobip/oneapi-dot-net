using System;
using log4net.Config;
using System.IO;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Exceptions;
using OneApi.Listeners;

namespace OneApi.Scenarios
{

    /**
    * To run this example follow these 4 steps:
    *
    *  1.) Download 'Parseco C# library' - available at www.github.com/parseco   or   www.parseco.com/apis    
    *
    *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project 
    *
    *  3.) Open 'Scenarios.GetInboundMessagesUsingRetriever' class to edit where you should populate the following fields: 
    *		'apiUrl'   
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
        private static string apiUrl = "http://api.parseco.com";
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";

        public static void Execute()
        {
            //Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            //Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));


            //Initialize Configuration object 
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;

            //Initialize SMSClient using the Configuration object
            SMSClient smsClient = new SMSClient(configuration);

            //Check if configured data is valid
            ValidateClientResponse validateClientResponse = smsClient.IsValid();
            if (validateClientResponse.IsValid.Equals(false))
            {
                Console.WriteLine("Configuration exception: " + validateClientResponse.ErrorMessage);
                return;
            }

            //Add listener(start retriever and pull Inbound Messages)    
            smsClient.SmsMessagingClient.AddPullInboundMessageListener(new InboundMessageListener(OnMessageReceived));

            //Waiting 2 minutes for the  'Inbound Message' before stop the retriever.   
            Console.WriteLine("Waiting 2 minutes for the Inbound Messages.. after that 'Incoming Messages' retriever will be stopped.");
            System.Threading.Thread.Sleep(120000);

            //Remove Inbound Messages Listeners and stop the retriever
            smsClient.SmsMessagingClient.RemovePullInboundMessageListeners();
        }

        //Handle pulled Inbound Messages
        private static void OnMessageReceived(InboundSMSMessageList smsMessageList, Exception e)
        {
            if (e == null)
            {
                Console.WriteLine("Inbound Messages " + string.Join("Inbound Message: ", (Object[])smsMessageList.InboundSMSMessage));
            }
            else
            {
                Console.WriteLine("Request Exception: " + e.Message);
            }
        }
    }
}
