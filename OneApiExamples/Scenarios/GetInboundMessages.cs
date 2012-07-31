using System;
using System.IO;
using log4net.Config;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Exceptions;

namespace OneApi.Scenarios
{

    /**
     * To run this example follow these 3 steps:
     *
     *  1.) Download 'OneApiExample' project - available at www.github.com/parseco   or   www.parseco.com/apis    
     *
     *  2.) Open 'Scenarios.GetInboundMessages' class to edit where you should populate the following fields: 
     *		'apiUrl'   
     *		'username' 
     *		'password'  
     *
     *  3.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
     *       There you will enter the appropriate example number in the console and press 'Enter' key 
     *       on which the result will be displayed in the Console.
     **/

    public class GetInboundMessages 
    {
        private static string apiUrl = "http://api.parseco.com";
        private static string username = "";
        private static string password = "";
       
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

            try
            {
                //Get Inbound Messages
                InboundSMSMessageList inboundSMSMessageList = smsClient.SmsMessagingClient.GetInboundMessages();
                Console.WriteLine("Inbound Messages " + string.Join("Inbound Message: ", (Object[])inboundSMSMessageList.InboundSMSMessage));             
            }
            catch (RequestException e)
            {
                Console.WriteLine("Exception: " + e.Message); 
            }  
        }
    }

}