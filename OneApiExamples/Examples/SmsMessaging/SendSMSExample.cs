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
            SMSClient smsClient = new SMSClient(configuration);

            //Login user
            LoginResponse loginResponse = smsClient.CustomerProfileClient.Login();
            if (loginResponse.Verified == false)
            {
                Console.WriteLine("User is not verified!");
                return;
            }

            string requestId = smsClient.SmsMessagingClient.SendSMS(new SMSRequest(senderAddress, message, recipientAddress));
            Console.WriteLine("Request Id: " + requestId);       
        }
    }
}