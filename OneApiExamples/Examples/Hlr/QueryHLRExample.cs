using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.Hlr
{

    public class QueryHLRExample 
	{
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string address = "";

        public static void Execute()
		{
            Configuration configuration = new Configuration(username, password);    
			SMSClient smsClient = new SMSClient(configuration);

            Roaming roaming = smsClient.HlrClient.QueryHLR(address);
			Console.WriteLine("HLR: " + roaming);
		}
	}

}