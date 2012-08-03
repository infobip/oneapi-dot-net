using System;
using System.IO;
using log4net.Config;
using OneApi.Client.Impl;
using OneApi.Model;
using OneApi.Config;
using OneApi.Exceptions;
using OneApi.Listeners;

namespace OneApi.Scenarios
{

    /**
      * To run this example follow these 4 steps:
      *
      *  1.) Download 'Parseco C# library' - available at www.github.com/parseco   or   www.parseco.com/apis    
      *
      *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project    
      *
      *  3.) Open 'Scenarios.SendSMS_GetDeliveryReportsUsingRetriever' class to edit where you should populate the following fields: 
      *		'senderAddress' 'username' 
      *	    'message'       'password'
      *		'recipientAddress'	
      *
      *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
      *      There you will enter the appropriate example number in the console and press 'Enter' key 
      *      on which the result will be displayed in the Console.
      *       
      *  Note: 'Delivery Reports' are retrieved default every 5000 milisecons (5 seconds). Retrieving interval can be changed
      *  by setting the 'Configuration' property 'DlrRetrievingInterval'.
      **/

    public class SendSMS_GetDeliveryReportsUsingRetriever
    {
        private static string apiUrl = "http://api.parseco.com";
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string senderAddress = "";
        private static string message = "";
        private static string recipientAddress = "";

        public static void Execute()
        {
            //Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            //Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));


            //Initialize Configuration object 
            Configuration configuration = new Configuration(username, password);
            configuration.ApiUrl = apiUrl;

            //Initialize SMSClient using the Configuration object
            SMSClient smsClient = new SMSClient(configuration);

            try
            {
                //Login user
                LoginResponse loginResponse = smsClient.CustomerProfileClient.Login();
                if (loginResponse.Verified == false)
                {
                    Console.WriteLine("User is not verified!");
                    return;
                }

                //Add listener(start retriever and pull Delivery Reports)  
                smsClient.SmsMessagingClient.AddPullDeliveryReportListener(new DeliveryReportListener(OnDeliveryReportReceived));

                //Send SMS to 1 recipients (instead passing one recipient address you can put the recipeints addresses string array)
                string requestId = smsClient.SmsMessagingClient.SendSMS(new SMSRequest(senderAddress, message, recipientAddress));
                Console.WriteLine("Request Id: " +  requestId);

                //Waiting 2 minutes for the 'Delivery Reports' before stop the retriever.   
                Console.WriteLine("Waiting 2 minutes for the Delivery Reports.. after that 'Delivery Reports' retriever will be stopped.");
                System.Threading.Thread.Sleep(120000);

                //Logout user
                smsClient.CustomerProfileClient.Logout();
            }
            catch (RequestException e)
            {
                Console.WriteLine("Request Exception: " + e.Message);
            }

            //Remove Delivery Reports Listeners and stop the retriever
            smsClient.SmsMessagingClient.RemovePullDeliveryReportListeners();        
        }

        //Handle pulled Delivery Reports
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