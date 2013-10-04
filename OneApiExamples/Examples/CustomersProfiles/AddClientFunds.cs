using System;
using System.IO;
using log4net.Config;
using OneApi.Client.Impl;
using OneApi.Config;
using OneApi.Model;

namespace OneApi.Examples.CustomerProfiles
{
	public class AddClientFunds
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

			Console.WriteLine("");
			Console.Write("Currency Code: ");
			string currencyCode = Console.ReadLine();
			Console.Write("Account Key: ");
			string accountKey = Console.ReadLine();
			Console.Write("Description: ");
			string description = Console.ReadLine();
			Console.Write("Ammount: ");
			decimal ammount = Convert.ToDecimal(Console.ReadLine());

			var result = smsClient.CustomerProfileClient.AddClientFunds(currencyCode, accountKey, description, ammount);
			Console.WriteLine(result.ToString());
			Console.WriteLine();
		}
	}
}
