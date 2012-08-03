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
			SMSClient smsClient = new SMSClient(configuration);

            //Login user
            LoginResponse loginResponse = smsClient.CustomerProfileClient.Login();
            if (loginResponse.Verified == false)
            {
                Console.WriteLine("User is not verified!");
                return;
            }

            InboundSMSMessageList inboundSMSMessageList = smsClient.SmsMessagingClient.GetInboundMessages();
            Console.WriteLine("Inbound Messages " + string.Join("Inbound Message: ", (Object[])inboundSMSMessageList.InboundSMSMessage)); 
		}
	}

}