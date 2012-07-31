using System;
using OneApi.Config;

namespace OneApi.Examples.ConfigFile
{
    
    public class LoadDefaultConfigFileExample
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