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
      *  3.) Open 'Scenarios.SendHLRAsyncRequest_PushHLRNotification' class to edit where you should populate the following fields: 
      *		'address'   'username'    
      *		'notifyUrl' 'password'         
      *		
      *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
      *      There you will enter the appropriate example number in the console and press 'Enter' key 
      *      on which the result will be displayed in the Console.
      *
      *  Note: 'HLR Notifications' push server is started automatically by adding 'HLRNotificationsListener'
      *  using the 'AddPushHlrNotificationsListener' method. Default server port is 3002 and it can be changed by set the 
      *  'Configuration' property 'HlrPushServerSimulatorPort'. 
      **/

    public class SendHLRAsyncRequest_PushHLRNotification 
    {
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";    
        private static string address = "";
        private static string notifyUrl = ""; //e.g. "http://127.0.0.1:3002/" 3002=Default port for 'HLR Notifications' server simulator
                
        public static void Execute()
        {
            //Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            //Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));


            //Initialize Configuration object 
            Configuration configuration = new Configuration(username, password);
            
            //Initialize SMSClient using the Configuration object
            SMSClient smsClient = new SMSClient(configuration);
 
            try
            {
                //Login user
                LoginResponse loginResponse = smsClient.CustomerProfileClient.Login();
                if (loginResponse.Verified == false)
                {
                    Console.WriteLine("User is not verified!");
                    return;
                }

                //Add listener(start push server and wait for the HLR Notifications)
                smsClient.HlrClient.AddPushHlrNotificationsListener(new HLRNotificationsListener(OnHLRReceived));

                //Send HLR Request Asynchronously
                smsClient.HlrClient.QueryHLRAsync(address, notifyUrl);
                Console.WriteLine("Asynchronous HLR request sent successfully, waiting for the 'HLR Notification'...");

                //Logout user
                smsClient.CustomerProfileClient.Logout();
            }
            catch (RequestException e)
            {
                Console.WriteLine("Request Exception: " + e.Message);
            }  
        }

        //Handle pushed HLR Notification
        private static void OnHLRReceived(RoamingNotification roamingNotification)
        {
            Console.WriteLine("HLR: " + roamingNotification);
        }
    }
}