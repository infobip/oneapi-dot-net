using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Listeners;

namespace OneApi.Examples.SmsMessaging
{

    public class DeliveryReportsRetrieverExample : ExampleBase
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

            smsClient.SmsMessagingClient.AddPullDeliveryReportListener(new DeliveryReportListener(OnDeliveryReportReceived));

            //Stop the Dlr Retriever and release listeners
            //smsClient.SmsMessagingClient().ReleaseDeliveryReportListeners();    
		}

        private static void OnDeliveryReportReceived(DeliveryReport[] deliveryReports, Exception e)
        {
            if (e == null)
            {
                Console.WriteLine("Delivery Reports: " + string.Join("Delivery Report: ", (Object[])deliveryReports)); 
            }
            else
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
	}

}