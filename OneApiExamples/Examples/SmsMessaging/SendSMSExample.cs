using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Listeners;

namespace OneApi.Examples.SmsMessaging
{

    public class SendSMSExample : ExampleBase
    {

        private static string senderAddress = "";
        private static string message = "";
        private static string recipientAddress = "";

        public static void Execute(bool isInputConfigData)
        {
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;

            SMSClient smsClient = new SMSClient(configuration);

            string requestId = smsClient.SmsMessagingClient.SendSMS(new SMSRequest(senderAddress, message, recipientAddress));
            Console.WriteLine("Request Id: " + requestId);       
        }
    }
}