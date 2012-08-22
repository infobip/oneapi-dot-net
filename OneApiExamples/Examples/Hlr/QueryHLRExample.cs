using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.Hlr
{

    public class QueryHLRExample : ExampleBase
	{

        private static string address = "";

        public static void Execute()
		{
            Configuration configuration = new Configuration(username, password);    
			SMSClient smsClient = new SMSClient(configuration);

            //Login user
            LoginResponse loginResponse = smsClient.CustomerProfileClient.Login();
            if (loginResponse.Verified == false)
            {
                Console.WriteLine("User is not verified!");
                return;
            }

            Roaming roaming = smsClient.HlrClient.QueryHLR(address);
			Console.WriteLine("HLR: " + roaming);
		}
	}

}