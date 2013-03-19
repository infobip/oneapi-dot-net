using System;
using System.IO;
using log4net.Config;
using OneApi.Client.Impl;
using OneApi.Config;
using OneApi.Model;
using System.Collections.Generic;

namespace OneApi.Examples.Networks
{
    /**
      * To run this example follow these 4 steps:
      *
      *  1.) Download 'Parseco C# library' - available at www.github.com/parseco    
      *
      *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project
      *
      *  3.) Open 'Examples.GetNetworks' class to edit where you should populate the following fields: 
      *		'gsmNumbers'
      *		
      *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
      *      There you will enter the appropriate example number in the console and press 'Enter' key 
      *      on which the result will be displayed in the Console.
      **/

    public class GetNumbersInfo
    {
        private static string username = System.Configuration.ConfigurationManager.AppSettings.Get("Username");
        private static string password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
        private static List<string> gsmNumbers = new List<string>() { "1234567890", "0123456789", "9876543210", "0987654321" };

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
            NumberInfo[] numberInfo = smsClient.NetworksClient.ResolveMSISDNs(gsmNumbers);

            // Write reposonse
            Console.WriteLine(string.Join("Number Info: ", (Object[])numberInfo));
            Console.WriteLine();
        }
    }
}
