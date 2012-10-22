using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using log4net.Config;
using System.IO;

namespace OneApi.Examples.Ussd
{

    public class USSDExample
    {
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string destination = "";
        private static string message = "You language of choice?\n1. Java\n2. .NET";

        public static void Execute()
        {
            Configuration configuration = new Configuration(username, password);
            SMSClient smsClient = new SMSClient(configuration);

            String response = null;
            while (response == null || !"1".Equals(response))
            {
                InboundSMSMessage inboundMessage = smsClient.UssdClient.SendMessage(destination, message);
                response = inboundMessage.Message;
            }

            Console.WriteLine("Message: " + response);       
            smsClient.UssdClient.StopSession(destination, "Cool");
        }
    }
}