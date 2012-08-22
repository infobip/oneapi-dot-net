using System;
using System.Net;
using System.Text;
using System.IO;
using log4net.Config;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Exceptions;
using OneApi.Model;
using OneApi.Examples;
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
      *  3.) Open 'Scenarios.SendHLRRequest' class to edit where you should populate the following fields: 
      *		'address'    'password'   
      *		'username'        
      *		
      *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
      *      There you will enter the appropriate example number in the console and press 'Enter' key 
      *      on which the result will be displayed in the Console.
      **/

    public class SendHLRRequest
    {
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string address = "";
                     
        public static void Execute()
        {
            // Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            // Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));

            try
            {
                // example:data-connection-client
                Configuration configuration = new Configuration(username, password);
                SMSClient smsClient = new SMSClient(configuration);
                LoginResponse loginResponse = smsClient.CustomerProfileClient.Login();
                // ----------------------------------------------------------------------------------------------------
                if (loginResponse.Verified == false)
                {
                    Console.WriteLine("User is not verified!");
                    return;
                }

                // example:retrieve-roaming-status
                Roaming roaming = smsClient.HlrClient.QueryHLR(address);
                // ----------------------------------------------------------------------------------------------------
                Console.WriteLine(roaming);

                // Logout sms client
                smsClient.CustomerProfileClient.Logout();
            }
            catch (RequestException e)
            {
                Console.WriteLine(e.Message); 
            }  
        }
    }
}