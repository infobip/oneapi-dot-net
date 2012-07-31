using System;
using System.IO;
using OneApi.Config;

namespace OneApi.Examples.ConfigFile
{
 
    public class SaveToConfigFileExample
	{

        public static void Execute()
		{
			//Initialize Configuration and load data from the configuration file
			Configuration configuration = new Configuration(true);

			//Set data you want to update
            configuration.VersionOneAPISMS = 2;
			configuration.DlrRetrievingInterval = 20000;
			configuration.InboundMessagesRetrievingInterval = 30000;

            //Save data to the specific configuration file		
            configuration.Save(Directory.GetCurrentDirectory() + "\\client.cfg");

            Console.WriteLine("Data saved successfully to the config file.");
         
		}
	}

}