using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;


namespace OneApi.Examples.SmsMessaging
{
    public class GetDeliveryReportsExample : ExampleBase
    { 

        public static void Execute(bool isInputConfigData) 
        {        
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;

            SMSClient smsClient = new SMSClient(configuration);

            DeliveryReport[] deliveryReports = smsClient.SmsMessagingClient.GetDeliveryReports();
            Console.WriteLine("Delivery Reports: " + string.Join("Delivery Report: ", (Object[])deliveryReports)); 
        }    
    }

}