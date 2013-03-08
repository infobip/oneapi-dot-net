using System;
using System.IO;
using log4net.Config;
using OneApi.Client.Impl;
using OneApi.Config;
using OneApi.Model;
using System.Collections.Generic;

namespace OneApiExamples.Examples.Networks
{
    /**
      * To run this example follow these 4 steps:
      *
      *  1.) Download 'Parseco C# library' - available at www.github.com/parseco    
      *
      *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project
      *
      *  3.) Open 'Examples.GetNetworks' class to edit where you should populate the following fields: 
      *		'password'   
      *		'username'  
      *		'gsmNumbers'
      *		
      *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
      *      There you will enter the appropriate example number in the console and press 'Enter' key 
      *      on which the result will be displayed in the Console.
      **/

    public class GetNumbersInfo
    {
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static List<string> gsmNumbers = new List<string>() { "38598123456", "38591654321", "38595987654" };

        public static void Execute()
        {
            // Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            // Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));

            // Initialize Configuration object 
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = "http://127.0.0.1:8099/infobip-oneapi";

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
