using log4net.Config;
using System;
using System.IO;
using OneApi.Config;

namespace OneApi.Examples.Logger
{
   
	public class EnableLoggerExample
	{
        protected static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public static void Execute()
		{
            //Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
     
            //1.) All Logger levels are enabled
            //BasicConfigurator.Configure();

            //2.) Configure in the file which Logger levels are enabled
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));

 
            //Load Data to see Logger info
            Configuration configuration = new Configuration();      
            configuration.Load("client.cfg"); 
        }
	}
}