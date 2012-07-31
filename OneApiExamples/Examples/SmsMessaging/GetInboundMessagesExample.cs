using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

	public class GetInboundMessagesExample : ExampleBase
	{

		public static void Execute(bool isInputConfigData)
		{
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;

			SMSClient smsClient = new SMSClient(configuration);

            InboundSMSMessageList inboundSMSMessageList = smsClient.SmsMessagingClient.GetInboundMessages();
            Console.WriteLine("Inbound Messages " + string.Join("Inbound Message: ", (Object[])inboundSMSMessageList.InboundSMSMessage)); 
		}
	}

}