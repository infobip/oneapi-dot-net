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
     *  3.) Open 'Examples.LoadDefaultConfigFile' class 
     *  
     *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
     *       There you will enter the appropriate example number in the console and press 'Enter' key 
     *       on which the result will be displayed in the Console.
     *       
     **/

    public class LoadDefaultConfigFile
	{

        public static void Execute()
		{
			//Initialize Configuration and load data from the default configuration file 
            //client.cfg - should be added to the application root folder
			Configuration configuration = new Configuration(true);

            //or..

            Configuration configuration1 = new Configuration();
            configuration1.Load();

            Console.WriteLine("Data loaded successfully from the configuration file.");   
		}
	}

}