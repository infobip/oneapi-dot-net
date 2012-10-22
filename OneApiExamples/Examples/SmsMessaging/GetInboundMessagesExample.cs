using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

	public class GetInboundMessagesExample
	{
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";

		public static void Execute()
		{
            Configuration configuration = new Configuration(username, password);          
			SMSClient smsClient = new SMSClient(configuration);

            InboundSMSMessageList inboundSMSMessageList = smsClient.SmsMessagingClient.GetInboundMessages();
            Console.WriteLine("Inbound Messages " + string.Join("Inbound Message: ", (Object[])inboundSMSMessageList.InboundSMSMessage)); 
		}
	}

}