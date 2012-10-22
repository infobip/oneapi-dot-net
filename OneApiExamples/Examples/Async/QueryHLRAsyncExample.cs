using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Listeners;

namespace OneApi.Examples.Async
{

    public class QueryHLRAsyncExample 
    {
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string address = "";

        public static void Execute()
        {
            Configuration configuration = new Configuration(username, password);
            SMSClient smsClient = new SMSClient(configuration);

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