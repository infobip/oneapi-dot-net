using System;
using OneApi.Config;
using System.IO;

namespace OneApi.Examples.ConfigFile
{
  
	public class LoadConfigFileExample 
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