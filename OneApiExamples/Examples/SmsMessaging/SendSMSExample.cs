using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Listeners;

namespace OneApi.Examples.SmsMessaging
{

    public class SendSMSExample 
    {
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string senderAddress = "";
        private static string message = "";
        private static string recipientAddress = "";

        public static void Execute()
        {
            Configuration configuration = new Configuration(username, password);      
            SMSClient smsClient = new SMSClient(configuration);

            string requestId = smsClient.SmsMessagingClient.SendSMS(new SMSRequest(senderAddress, message, recipientAddress));
            Console.WriteLine("Request Id: " + requestId);       
        } 
    }
}