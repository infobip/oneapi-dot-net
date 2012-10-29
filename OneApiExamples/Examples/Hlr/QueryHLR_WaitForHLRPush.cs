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

namespace OneApi.Examples.Hlr
{

    /**
      * To run this example follow these 4 steps:
      *
      *  1.) Download 'Parseco C# library' - available at www.github.com/parseco    
      *
      *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project    
      *
      *  3.) Open 'Examples.QueryHLR_WaitForHLRPush' class to edit where you should populate the following fields: 
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

    public class QueryHLR_WaitForHLRPush 
    {
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string address = "";
        private static string notifyUrl = ""; //e.g. "http://127.0.0.1:3002/" 3002=Default port for 'HLR Notifications' server simulator
                
        public static void Execute()
        {
            // Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            // Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));

            try
            {
                // Initialize Configuration object 
                Configuration configuration = new Configuration(username, password);

                // Initialize SMSClient using the Configuration object
                SMSClient smsClient = new SMSClient(configuration);

                // Add listener(start push server and wait for the 'HLR Notifications')
                smsClient.HlrClient.AddPushHLRNotificationsListener(new HLRNotificationsListener((roamingNotification) =>
                {
                    // Handle pushed 'HLR Notification'
                    if (roamingNotification != null)
                    {
                        Console.WriteLine(roamingNotification);
                    }
                }));

                // example:retrieve-roaming-status-with-notify-url
                smsClient.HlrClient.QueryHLR(address, notifyUrl);
                // ----------------------------------------------------------------------------------------------------

                // Wait 30 seconds for 'HLR Notification' push-es before closing the server connection 
                System.Threading.Thread.Sleep(30000);

                // Remove 'HLR Notification' push listeners and stop the server
                smsClient.HlrClient.RemovePushHLRNotificationsListeners();
            }
            catch (RequestException e)
            {
                Console.WriteLine(e.Message);
            }  
        }
    }
}