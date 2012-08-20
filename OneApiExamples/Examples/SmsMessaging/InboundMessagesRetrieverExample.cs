using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Listeners;

namespace OneApi.Examples.SmsMessaging
{
   
	public class InboundMessagesRetrieverExample : ExampleBase
	{

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

            smsClient.SmsMessagingClient.AddPullInboundMessageListener(new InboundMessageListener(OnMessageReceived));

            //Stop the Inbound Messages Getr and release listeners
            //smsClient.SmsMessagingClient.ReleaseInboundMessageListeners();       
        }

        private static void OnMessageReceived(InboundSMSMessageList smsMessageList, Exception e)
        {
            if (e == null)
            {
                Console.WriteLine("Inbound Messages " + string.Join("Inbound Message: ", (Object[])smsMessageList.InboundSMSMessage)); 
            }
            else
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}