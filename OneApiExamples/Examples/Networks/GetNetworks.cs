using System;
using System.IO;
using log4net.Config;
using OneApi.Client.Impl;
using OneApi.Config;
using OneApi.Model;

namespace OneApi.Examples.Networks
{
    /**
      * To run this example follow these 3 steps:
      *
      *  1.) Download 'Parseco C# library' - available at www.github.com/parseco    
      *
      *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project       
      *		
      *  3.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
      *      There you will enter the appropriate example number in the console and press 'Enter' key 
      *      on which the result will be displayed in the Console.
      **/

    public class GetNetworks
    {
        private static string username = System.Configuration.ConfigurationManager.AppSettings.Get("Username");
        private static string password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");

        public static void Execute()
        {
            // Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            // Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));

            // Initialize Configuration object 
            Configuration configuration = new Configuration(username, password);

            // Initialize SMSClient using the Configuration object
            SMSClient smsClient = new SMSClient(configuration);

            // Querry for networks
            Network[] networks = smsClient.NetworksClient.GetNetworks();

            // Write response
            Console.WriteLine(string.Join("Network: ", (Object[])networks));
            Console.WriteLine();
        }
    }
}
