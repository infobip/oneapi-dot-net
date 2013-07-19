using System;
using OneApi.Config;

namespace OneApi.Examples.ConfigFile
{

    /**
     * To run this example follow these 4 steps:
     *
     *  1.) Download 'Infobip C# library' - available at www.github.com/infobip     
     *
     *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project 
     *
     *  3.) Open 'Examples.SaveToDefaultConfigFile' class 
     *  
     *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
     *       There you will enter the appropriate example number in the console and press 'Enter' key 
     *       on which the result will be displayed in the Console.
     *       
     **/

    public class SaveToDefaultConfigFile
	{

        public static void Execute()
		{
			//Initialize Configuration and load data from the configuration file
			Configuration configuration = new Configuration(true);
          
			//Set data you want to update
            configuration.VersionOneAPISMS = 2;
			configuration.DlrRetrievingInterval = 20000;
			configuration.InboundMessagesRetrievingInterval = 30000;

            //Save data to default configuration file	
            //client.cfg - should be added to the application root folder
            configuration.Save();

            Console.WriteLine("Data saved successfully to the config file.");
            
		}
	}

}