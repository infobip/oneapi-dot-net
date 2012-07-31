using System;

namespace OneApi.Examples.SmsMessaging
{

	using SMSClient = OneApi.Client.Impl.SMSClient;
	using Configuration = OneApi.Config.Configuration;
	using DeliveryReportListener =OneApi.Listeners.DeliveryReportListener;
	using DeliveryReport = OneApi.Model.DeliveryReport;
	using ResourceReference = OneApi.Model.ResourceReference;
	using SMSRequest = OneApi.Model.SMSRequest;

    public class DeliveryReportsRetrieverExample : ExampleBase
	{

		public static void Execute(bool isInputConfigData)
		{  
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;

			SMSClient smsClient = new SMSClient(configuration);

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