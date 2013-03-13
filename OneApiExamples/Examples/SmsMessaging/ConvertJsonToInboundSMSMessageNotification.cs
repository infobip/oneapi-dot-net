using System;
using OneApi.Client.Impl;
using OneApi.Config;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

    /**
    * To run this example follow these 4 steps:
    *
    *  1.) Download 'Parseco C# library' - available at www.github.com/parseco  
    *
    *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project 
    *
    *  3.) Open 'Examples.ConvertJsonToInboundSMSMessageNotification' class 
    *  
    *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
    *       There you will enter the appropriate example number in the console and press 'Enter' key 
    *       on which the result will be displayed in the Console.
    *       
    **/

    public class ConvertJsonToInboundSMSMessageNotification
	{
        // Pushed 'Inbound Message Notification' JSON example
        private const string JSON = "{\"inboundSMSMessage\":[{\"dateTime\":1343893501000,\"destinationAddress\":\"7567567657\",\"callbackData\":\"testCallback\",\"moResponseKey\":\"repoKey\",\"price\":\"5\",\"messageId\":null,\"message\":\"TestCriteria\",\"resourceURL\":null,\"senderAddress\":\"76756\",\"moSessionId\":0}],\"numberOfMessagesInThisBatch\":1,\"resourceURL\":null,\"totalNumberOfPendingMessages\":0,\"callbackData\":null}";

        public static void Execute()
        {
            Configuration configuration = new Configuration();
            SMSClient smsClient = new SMSClient(configuration);

            // example:on-mo
            InboundSMSMessageList inboundSMSMessageList = smsClient.SmsMessagingClient.ConvertJsonToInboundSMSMessageNotification(JSON);
            // ----------------------------------------------------------------------------------------------------
            Console.WriteLine(inboundSMSMessageList); 
        }
	}
}