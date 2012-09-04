using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Listeners;

namespace OneApi.Examples.Async
{

    public class QueryHLRAsyncExample : ExampleBase
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

            smsClient.HlrClient.QueryHLRAsync(address, (roaming, e) =>
            {
                if (e == null)
                {
                    Console.WriteLine("HLR: " + roaming);
                }
                else
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            });

        }
    }
}