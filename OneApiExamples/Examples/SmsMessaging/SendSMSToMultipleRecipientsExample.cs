using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

	public class SendSMSToMultipleRecipientsExample : ExampleBase
	{

        private static string senderAddress = "";
        private static string message = "";
        private static string recipientAddress1 = "";
        private static string recipientAddress2 = "";

		public static void Execute(bool isInputConfigData)
		{
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;

			SMSClient smsClient = new SMSClient(configuration);

            //Login user
            LoginResponse loginResponse = smsClient.CustomerProfileClient.Login();
            if (loginResponse.Verified == false)
            {
                Console.WriteLine("User is not verified!");
                return;
            }

			string[] address = new string[2];
            address[0] = recipientAddress1;
            address[1] = recipientAddress2;

            SMSRequest smsRequest = new SMSRequest(senderAddress, message, address);

            string requestId = smsClient.SmsMessagingClient.SendSMS(smsRequest);
            Console.WriteLine("Request Id: " + requestId);
		}
	}

}