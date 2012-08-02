using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.Hlr
{

    public class QueryHLRSyncExample : ExampleBase
	{

        private static string address = "";

        public static void Execute(bool isInputConfigData)
		{
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("OneApiExamples.exe.config"));

            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;

			SMSClient smsClient = new SMSClient(configuration);

            Roaming roaming = smsClient.HlrClient.QueryHLRSync(address);
			Console.WriteLine("HLR: " + roaming);
		}
	}

}