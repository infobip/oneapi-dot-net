using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using log4net.Config;
using OneApi.Client.Impl;
using OneApi.Config;
using OneApi.Model;

namespace OneApi.Examples.CustomerProfiles
{
	class GetCustomerProfileClients
	{
		public static void Execute()
		{
			// Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
			// Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
			XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));

			// Initialize Configuration object 
			Configuration configuration = new Configuration(System.Configuration.ConfigurationManager.AppSettings.Get("Username"),
															System.Configuration.ConfigurationManager.AppSettings.Get("Password"));
			// Initialize SMSClient using the Configuration object
			SMSClient smsClient = new SMSClient(configuration);

			CustomerProfile[] customerProfiles = smsClient.CustomerProfileClient.GetClients();
			Console.WriteLine(string.Join("Customer Profile: ", (Object[])customerProfiles));
			Console.WriteLine();
		}
	}
}
