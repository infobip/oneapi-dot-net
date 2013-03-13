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
     *  3.) Open 'Examples.LoadConfigFile' class 
     *  
     *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
     *       There you will enter the appropriate example number in the console and press 'Enter' key 
     *       on which the result will be displayed in the Console.
     *       
     **/

    public class LoadConfigFile
	{

        public static void Execute()
		{
			//Initialize Configuration 
			Configuration configuration = new Configuration();
           
            //Load data from the specific configuration file
            configuration.Load(Directory.GetCurrentDirectory() + "\\client.cfg");

            Console.WriteLine("Data loaded successfully from the configuration file.");  
		}
	}

}