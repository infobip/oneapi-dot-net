using System;
using System.IO;
using OneApi.Config;

namespace OneApi.Examples.ConfigFile
{

    /**
     * To run this example follow these 4 steps:
     *
     *  1.) Download 'Parseco C# library' - available at www.github.com/parseco     
     *
     *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project 
     *
     *  3.) Open 'Examples.SaveToConfigFile' class 
     *  
     *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
     *       There you will enter the appropriate example number in the console and press 'Enter' key 
     *       on which the result will be displayed in the Console.
     *       
     **/

    public class SaveToConfigFile
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