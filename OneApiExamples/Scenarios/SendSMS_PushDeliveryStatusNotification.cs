using System;
using System.Net;
using System.Text;
using System.IO;
using log4net.Config;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Exceptions;
using OneApi.Model;
using OneApi.Examples;
using OneApi.Listeners;

namespace OneApi.Scenarios
{

    /**
      * To run this example follow these 3 steps:
      *
      *  1.) Download 'OneApiExample' project - available at www.github.com/parseco   or   www.parseco.com/apis    
      *
      *  2.) Open 'Scenarios.SendSMS' class to edit where you should populate the following fields: 
      *		'senderAddress'     'notifyUrl'   'username'
      *		'message'           'criteria'    'password'        
      *		'recipientAddress'   
      *
      *  3.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
      *       There you will enter the appropriate example number in the console and press 'Enter' key 
      *       on which the result will be displayed in the Console.
      *
      *  Note: 'Delivery Status Notifications' push server is started automatically by adding 'DeliveryStatusNotificationsListener'
      *  using the 'AddPushDeliveryStatusNotificationListener' method. Default server port is 3000 and it can be changed by set the 
      *  'Configuration' property 'DlrStatusPushServerPort'. Used port should match the one used in the 'notifyUrl' property when 
      *  subscribing for the notifications using the 'SubscribeToDeliveryStatusNotifications' method.
      **/

    public class SendSMS_PushDeliveryStatusNotification 
    {
        private static string apiUrl = "http://api.parseco.com";
        private static string username = "FILL USERNAME HERE !!!";
        private static string password = "FILL PASSWORD HERE !!!";
        private static string senderAddress = "";
        private static string message = "";
        private static string recipientAddress = "";
        private static string notifyUrl = ""; //e.g. "http://127.0.0.1:3000/" 3000=Default port for 'Delivery status Notifications' server simulator
        private static string criteria = "";
           
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

            //Add listener(start push server and wait for the Delivery Status Notifications)    
            smsClient.SmsMessagingClient.AddPushDeliveryStatusNotificationListener(new DeliveryStatusNotificationsListener(OnDeliveryInfoNotificationReceived));
         
            try
            {      
                //Subscribe to the Delivery Status notifications
                string subscriptionId = smsClient.SmsMessagingClient.SubscribeToDeliveryStatusNotifications(new SubscribeToDeliveryNotificationsRequest(senderAddress, notifyUrl, criteria, "", ""));
                Console.WriteLine("Subscription Id: " + subscriptionId);

                //Send SMS to 1 recipients (instead passing one recipient address you can put the recipeints addresses string array)
                string requestId = smsClient.SmsMessagingClient.SendSMS(new SMSRequest(senderAddress, criteria + message, recipientAddress));
                Console.WriteLine("Request Id: " + requestId);

                //Waiting 2 minutes for the  'Delivery Info Notification' before close the server connection and canceling subscription.   
                Console.WriteLine("Waiting 2 minutes for the Delivery Info Notifications.. after that subscription will be removed and push server connection will be closed."); 
                System.Threading.Thread.Sleep(120000);

                //Remove Delivery Status Notifications subscription
                smsClient.SmsMessagingClient.RemoveDeliveryNotificationsSubscription(subscriptionId);

                //Remove Delivery Status Notification Listeners and stop the server
                smsClient.SmsMessagingClient.RemovePushDeliveryStatusNotificationListeners();     
            }
            catch (RequestException e)
            {
                Console.WriteLine("Exception: " + e.Message); 
            }  
        }

        //Handle pushed Delivery Info Notification
        private static void OnDeliveryInfoNotificationReceived(DeliveryInfoNotification deliveryInfoNotification)
        {
            if (deliveryInfoNotification != null) 
            {
                Console.WriteLine("Delivery Info Notification " + deliveryInfoNotification);
            }  
        }
    }
}