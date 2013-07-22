using System;
using System.IO;
using log4net.Config;
using OneApi.Client.Impl;
using OneApi.Config;
using OneApi.Model;

namespace OneApi.Examples.Ussd
{

    /**
     * To run this example follow these 4 steps:
     *
     *  1.) Download 'Infobip C# library' - available at www.github.com/infobip 
     *
     *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project    
     *
     *  3.) Open 'Examples.SendUSSD' class to edit where you should populate the following fields: 	        
     *		'message'
     *		'destination'
     *
     *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
     *      There you will enter the appropriate example number in the console and press 'Enter' key 
     *      on which the result will be displayed in the Console.      
    **/

    public class SendUSSD
    {
        private static string destination = "";
        private static string message = "You language of choice?\n1. Java\n2. .NET";

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

            String response = null;
            while (response == null || !"1".Equals(response))
            {
                // Send USSD and wait for the answer
                InboundSMSMessage inboundMessage = smsClient.UssdClient.SendMessage(destination, message);
                response = inboundMessage.Message;
            }

            // Send message and stop USSD session   
            smsClient.UssdClient.StopSession(destination, "Cool");
        }
    }
}