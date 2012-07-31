using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.SmsMessaging
{

	public class GetInboundMessagesNotificationsSubscriptionsExample : ExampleBase
	{

		public static void Execute(bool isInputConfigData)
		{
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;

			SMSClient smsClient = new SMSClient(configuration);

            MoSubscription[] moSubscriptions = smsClient.SmsMessagingClient.GetInboundMessagesSubscriptions();
            Console.WriteLine("MO Subscriptions: " + string.Join("MO Subscription: ", (Object[])moSubscriptions));
		}
	}

}