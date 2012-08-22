using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

    public class ConvertJsonToInboundSMSMessageNotificationExample
	{
        private const string JSON = "{\"inboundSMSMessage\":[{\"dateTime\":1343893501000,\"destinationAddress\":\"7567567657\",\"messageId\":null,\"message\":\"TestCriteria\",\"resourceURL\":null,\"senderAddress\":\"76756\",\"moSessionId\":0}],\"numberOfMessagesInThisBatch\":1,\"ResourceURL\":null,\"totalNumberOfPendingMessages\":0,\"callbackData\":null}";

        public static void Execute()
        {
            Configuration configuration = new Configuration();
            SMSClient smsClient = new SMSClient(configuration);

            InboundSMSMessageList inboundSMSMessageList = smsClient.SmsMessagingClient.ConvertJsonToInboundSMSMessageNotification(JSON);           
            Console.WriteLine("Inbound Messages: " + inboundSMSMessageList); 
        }
	}

}