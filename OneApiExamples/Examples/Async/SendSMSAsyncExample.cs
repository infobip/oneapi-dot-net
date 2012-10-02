using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Listeners;

namespace OneApi.Examples.Async
{

    public class SendSMSAsyncExample : ExampleBase
    {

        private static string senderAddress = "";
        private static string message = "";
        private static string recipientAddress = "";

        public static void Execute()
        {
            Configuration configuration = new Configuration(username, password);
            SMSClient smsClient = new SMSClient(configuration);

            smsClient.SmsMessagingClient.SendSMSAsync(new SMSRequest(senderAddress, message, recipientAddress), (requestId, e) =>
            {
                if (e == null)
                {
                    Console.WriteLine("Request Id: " + requestId);
                }
                else
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            });

        }
    }
}