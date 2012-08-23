using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Scenarios
{

    /**
    * To run this example follow these 4 steps:
    *
    *  1.) Download 'Parseco C# library' - available at www.github.com/parseco   or   www.parseco.com/apis    
    *
    *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project 
    *
    *  3.) Open 'Scenarios.ConvertJsonToInboundSMSMessageNotificationExample' class to edit where you should populate the following fields: 
    *		'username' 
    *		'password'  
    *
    *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
    *       There you will enter the appropriate example number in the console and press 'Enter' key 
    *       on which the result will be displayed in the Console.
    *       
    **/

    public class ConvertJsonToInboundSMSMessageNotificationExample
	{
        // Pushed 'Inbound Message Notification' JSON example
        private const string JSON = "{\"inboundSMSMessage\":[{\"dateTime\":1343893501000,\"destinationAddress\":\"7567567657\",\"messageId\":null,\"message\":\"TestCriteria\",\"resourceURL\":null,\"senderAddress\":\"76756\",\"moSessionId\":0}],\"numberOfMessagesInThisBatch\":1,\"resourceURL\":null,\"totalNumberOfPendingMessages\":0,\"callbackData\":null}";

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