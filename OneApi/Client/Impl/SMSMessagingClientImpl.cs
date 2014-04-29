using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using OneApi.Retrievers;
using OneApi.Listeners;
using OneApi.Config;
using OneApi.Model;
using RestSharp;
using OneApi.Exceptions;

namespace OneApi.Client.Impl
{
    public class SMSMessagingClientImpl : OneAPIBaseClientImpl, SMSMessagingClient
    {
        private const string SMS_MESSAGING_OUTBOUND_URL_BASE = "/smsmessaging/outbound";
        private const string SMS_MESSAGING_INBOUND_URL_BASE = "/smsmessaging/inbound";
        private DeliveryReportRetriever deliveryReportRetriever = null;
        private InboundMessageRetriever inboundMessageRetriever = null;
        private volatile IList<DeliveryReportListener> deliveryReportPullListenerList = null;
        private volatile IList<InboundMessageListener> inboundMessagePullListenerList = null;
        private volatile IList<DeliveryStatusNotificationsListener> deliveryStatusNotificationPushListenerList = null;
        private volatile IList<InboundMessageNotificationsListener> inboundMessagePushListenerList = null;
        private PushServerSimulator dlrStatusPushServerSimulator;
        private PushServerSimulator inboundMessagesPushServerSimulator;
        //*************************SMSMessagingClientImpl Initialization******************************************************************************************************************************************************
        public SMSMessagingClientImpl(Configuration configuration)
            : base(configuration)
        {
        }
        //*************************SMSMessagingClientImpl public******************************************************************************************************************************************************
        /// <summary>
        /// Send an SMS over OneAPI to one or more mobile terminals using the customized 'SMS' object </summary>
        /// <param name="sms"> (mandatory) object containing data needed to be filled in order to send the SMS </param>
        /// <returns> SendMessageResult </returns>
        public SendMessageResult SendSMS(SMSRequest smsRequest)
        {
            StringBuilder urlBuilder = new StringBuilder(SMS_MESSAGING_OUTBOUND_URL_BASE).Append("/");
            urlBuilder.Append(HttpUtility.UrlEncode(smsRequest.SenderAddress));
            urlBuilder.Append("/requests");

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.POST, null, smsRequest);
            requestData.ContentType = RequestData.JSON_CONTENT_TYPE;
            return ExecuteMethod<SendMessageResult>(requestData);
        }

        /// <summary>
        /// Send an SMS asynchronously over OneAPI to one or more mobile terminals using the customized 'SMS' object </summary>
        /// <param name="sms"> (mandatory) object containing data needed to be filled in order to send the SMS </param>
        /// <param name="callback"> (mandatory) method to call after receiving sent SMS response </param>
        public void SendSMSAsync(SMSRequest smsRequest, System.Action<SendMessageResult, RequestException> callback)
        {
            StringBuilder urlBuilder = new StringBuilder(SMS_MESSAGING_OUTBOUND_URL_BASE).Append("/");
            urlBuilder.Append(HttpUtility.UrlEncode(smsRequest.SenderAddress));
            urlBuilder.Append("/requests");

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.POST, null, smsRequest);
            requestData.ContentType = RequestData.JSON_CONTENT_TYPE;
            ExecuteMethodAsync<SendMessageResult>(requestData, callback);
        }

        /// <summary>
        /// Query the delivery status over OneAPI for an SMS sent to one or more mobile terminals </summary>
        /// <param name="senderAddress"> (mandatory) is the address from which SMS messages are being sent. Do not URL encode this value prior to passing to this function </param>
        /// <param name="requestId"> (mandatory) contains the requestId returned from a previous call to the sendSMS function </param>
        /// <returns> DeliveryInfoList </returns>
        public DeliveryInfoList QueryDeliveryStatus(string senderAddress, string requestId)
        {
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_OUTBOUND_URL_BASE)).Append("/");
            urlBuilder.Append(HttpUtility.UrlEncode(senderAddress));
            urlBuilder.Append("/requests/");
            urlBuilder.Append(HttpUtility.UrlEncode(requestId));
            urlBuilder.Append("/deliveryInfos");

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.GET, "deliveryInfoList");
            return ExecuteMethod<DeliveryInfoList>(requestData);
        }

        /// <summary>
        /// Query the delivery status asynchronously over OneAPI for an SMS sent to one or more mobile terminals </summary>
        /// <param name="senderAddress"> (mandatory) is the address from which SMS messages are being sent. Do not URL encode this value prior to passing to this function </param>
        /// <param name="requestId"> (mandatory) contains the requestId returned from a previous call to the sendSMS function </param>
        /// <param name="callback"> (mandatory) method to call after receiving delivery status </param>
        public void QueryDeliveryStatusAsync(string senderAddress, string requestId, Action<DeliveryInfoList, RequestException> callback)
        {
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_OUTBOUND_URL_BASE)).Append("/");
            urlBuilder.Append(HttpUtility.UrlEncode(senderAddress));
            urlBuilder.Append("/requests/");
            urlBuilder.Append(HttpUtility.UrlEncode(requestId));
            urlBuilder.Append("/deliveryInfos");

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.GET, "deliveryInfoList");
            ExecuteMethodAsync<DeliveryInfoList>(requestData, callback);
        }

        /// <summary>
        /// Convert JSON to Delivery Info Notification </summary>
        /// <returns> DeliveryInfoNotification </returns>
        public DeliveryInfoNotification ConvertJsonToDeliveryInfoNotification(string json)
        {
            return ConvertJsonToObject<DeliveryInfoNotification>(json, "deliveryInfoNotification");
        }

        /// <summary>
        /// Start subscribing to delivery status notifications over OneAPI for all your sent SMS </summary>
        /// <param name="subscribeToDeliveryNotificationsRequest"> (mandatory) contains delivery notifications subscription data </param>
        /// <returns> string - Subscription Id  </returns>
        public string SubscribeToDeliveryStatusNotifications(SubscribeToDeliveryNotificationsRequest subscribeToDeliveryNotificationsRequest)
        {
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_OUTBOUND_URL_BASE)).Append("/");

            if (null != subscribeToDeliveryNotificationsRequest.SenderAddress)
            {
                urlBuilder.Append(HttpUtility.UrlEncode(subscribeToDeliveryNotificationsRequest.SenderAddress)).Append("/");
            }
            urlBuilder.Append("subscriptions");

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.POST, "deliveryReceiptSubscription", subscribeToDeliveryNotificationsRequest);
            DeliveryReceiptSubscription reliveryReceiptSubscription = ExecuteMethod<DeliveryReceiptSubscription>(requestData);
            return GetIdFromResourceUrl(reliveryReceiptSubscription.ResourceURL);
        }

        /// <summary>
        /// Get delivery notifications subscriptions by sender address </summary>
        /// <param name="senderAddress"> </param>
        /// <returns> DeliveryReportSubscription[] </returns>
        public DeliveryReportSubscription[] GetDeliveryNotificationsSubscriptionsBySender(string senderAddress)
        {
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_OUTBOUND_URL_BASE)).Append("/");
            urlBuilder.Append(HttpUtility.UrlEncode(senderAddress));
            urlBuilder.Append("/subscriptions");

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.GET, "deliveryReceiptSubscriptions");
            return ExecuteMethod<DeliveryReportSubscription[]>(requestData);
        }

        /// <summary>
        /// Get delivery notifications subscriptions by subscription id </summary>
        /// <param name="subscriptionId"> </param>
        /// <returns> DeliveryReportSubscription </returns>
        public DeliveryReportSubscription GetDeliveryNotificationsSubscriptionById(string subscriptionId)
        {
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_OUTBOUND_URL_BASE)).Append("/subscriptions/");
            urlBuilder.Append(HttpUtility.UrlEncode(subscriptionId));

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.GET, "deliveryReceiptSubscription");
            return ExecuteMethod<DeliveryReportSubscription>(requestData);
        }

        /// <summary>
        /// Get delivery notifications subscriptions by for the current user </summary>
        /// <returns> DeliveryReportSubscription[] </returns>
        public DeliveryReportSubscription[] GetDeliveryNotificationsSubscriptions()
        {
            RequestData requestData = new RequestData(SMS_MESSAGING_OUTBOUND_URL_BASE + "/subscriptions", Method.GET, "deliveryReceiptSubscriptions");
            return ExecuteMethod<DeliveryReportSubscription[]>(requestData);
        }

        /// <summary>
        /// Stop subscribing to delivery status notifications over OneAPI for all your sent SMS </summary>
        /// <param name="subscriptionId"> (mandatory) contains the subscriptionId of a previously created SMS delivery receipt subscription </param>
        public void RemoveDeliveryNotificationsSubscription(string subscriptionId)
        {
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_OUTBOUND_URL_BASE)).Append("/subscriptions/");
            urlBuilder.Append(HttpUtility.UrlEncode(subscriptionId));

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.DELETE);
            ExecuteMethod(requestData);
        }

        /// <summary>
        /// Get SMS messages sent to your Web application over OneAPI using default 'maxBatchSize' = 100 </summary>
        /// <returns> InboundSMSMessageList </returns>
        public InboundSMSMessageList GetInboundMessages()
        {
            return this.GetInboundMessages(100);
        }

        /// <summary>
        /// Get SMS messages sent to your Web application over OneAPI </summary>
        /// <param name="maxBatchSize"> (optional) is the maximum number of messages to get in this request </param>
        /// <returns> InboundSMSMessageList </returns>
        public InboundSMSMessageList GetInboundMessages(int maxBatchSize)
        {
            //Registration ID is obsolete so any string can be put: e.g. INBOUND
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_INBOUND_URL_BASE)).Append("/registrations/INBOUND/messages");
            urlBuilder.Append("?maxBatchSize=");
            urlBuilder.Append(HttpUtility.UrlEncode(Convert.ToString(maxBatchSize)));

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.GET, "inboundSMSMessageList");
            return ExecuteMethod<InboundSMSMessageList>(requestData);
        }

        /// <summary>
        /// Get asynchronously SMS messages sent to your Web application over OneAPI </summary>
        /// <param name="callback"> (mandatory) method to call after receiving inbound messages </param>
        public void GetInboundMessagesAsync(Action<InboundSMSMessageList, RequestException> callback)
        {
            this.GetInboundMessagesAsync(100, callback);
        }

        /// <summary>
        /// Get asynchronously SMS messages sent to your Web application over OneAPI </summary>
        /// <param name="maxBatchSize"> (optional) is the maximum number of messages to get in this request </param>
        /// <param name="callback"> (mandatory) method to call after receiving inbound messages </param>
        public void GetInboundMessagesAsync(int maxBatchSize, Action<InboundSMSMessageList, RequestException> callback)
        {
            //Registration ID is obsolete so any string can be put: e.g. INBOUND
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_INBOUND_URL_BASE)).Append("/registrations/INBOUND/messages");
            urlBuilder.Append("?maxBatchSize=");
            urlBuilder.Append(HttpUtility.UrlEncode(Convert.ToString(maxBatchSize)));

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.GET, "inboundSMSMessageList");
            ExecuteMethodAsync<InboundSMSMessageList>(requestData, callback);
        }

        /// <summary>
        /// Convert JSON to Inbound SMS Message Notification </summary>
        /// <returns> InboundSMSMessageList </returns>
        public InboundSMSMessageList ConvertJsonToInboundSMSMessageNotification(string json)
        {
            return ConvertJsonToObject<InboundSMSMessageList>(json);
        }

        /// <summary>
        /// Start subscribing to notifications of SMS messages sent to your application over OneAPI </summary>
        /// <param name="subscribeToInboundMessagesRequest"> (mandatory) contains inbound messages subscription data </param>
        /// <returns>string - Subscription Id </returns>
        public string SubscribeToInboundMessagesNotifications(SubscribeToInboundMessagesRequest subscribeToInboundMessagesRequest)
        {
            RequestData requestData = new RequestData(SMS_MESSAGING_INBOUND_URL_BASE + "/subscriptions", Method.POST, "resourceReference", subscribeToInboundMessagesRequest);
            ResourceReference resourceReference = ExecuteMethod<ResourceReference>(requestData);
            return GetIdFromResourceUrl(resourceReference.ResourceURL);
        }

        /// <summary>
        /// Get inbound messages notifications subscriptions for the current user </summary>
        /// <returns> MoSubscription[] </returns>
        public MoSubscription[] GetInboundMessagesNotificationsSubscriptions(int page, int pageSize)
        {
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_INBOUND_URL_BASE)).Append("/subscriptions");
            urlBuilder.Append("?page=");
            urlBuilder.Append(HttpUtility.UrlEncode(Convert.ToString(page)));
            urlBuilder.Append("&pageSize=");
            urlBuilder.Append(HttpUtility.UrlEncode(Convert.ToString(pageSize)));

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.GET, "subscriptions");
            return ExecuteMethod<MoSubscription[]>(requestData);
        }

        /// <summary>
        /// Get inbound messages notifications subscriptions for the current user </summary>
        /// <returns> MoSubscription[] </returns>
        public MoSubscription[] GetInboundMessagesNotificationsSubscriptions()
        {
            return GetInboundMessagesNotificationsSubscriptions(1, 10);
        }

        /// <summary>
        /// Stop subscribing to message receipt notifications for all your received SMS over OneAPI </summary>
        /// <param name="subscriptionId"> (mandatory) contains the subscriptionId of a previously created SMS message receipt subscription </param>
        public void RemoveInboundMessagesNotificationsSubscription(string subscriptionId)
        {
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_INBOUND_URL_BASE)).Append("/subscriptions/");
            urlBuilder.Append(HttpUtility.UrlEncode(subscriptionId));

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.DELETE);
            ExecuteMethod(requestData);
        }

        /// <summary>
        /// Get delivery reports
        /// </summary>
        public DeliveryReportList GetDeliveryReports()
        {
            return GetDeliveryReports(0);
        }

        /// <summary>
        /// Get delivery reports asynchronously</summary>
        /// <param name="callback"> (mandatory) method to call after receiving delivery reports </param>
        public void GetDeliveryReportsAsync(Action<DeliveryReportList, RequestException> callback)
        {
            this.GetDeliveryReportsAsync(0, callback);
        }

        /// <summary>
        /// Get delivery reports </summary>
        /// <param name="limit"> </param>
        /// <returns> DeliveryReportList </returns>
        public DeliveryReportList GetDeliveryReports(int limit)
        {
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_OUTBOUND_URL_BASE)).Append("/requests/deliveryReports");
            urlBuilder.Append("?limit=");
            urlBuilder.Append(HttpUtility.UrlEncode(Convert.ToString(limit)));

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.GET);
            return ExecuteMethod<DeliveryReportList>(requestData);
        }

        /// <summary>
        /// Get delivery reports asynchronously</summary>
        /// <param name="limit"> </param>
        /// <param name="callback"> (mandatory) method to call after receiving delivery reports </param>
        public void GetDeliveryReportsAsync(int limit, Action<DeliveryReportList, RequestException> callback)
        {
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_OUTBOUND_URL_BASE)).Append("/requests/deliveryReports");
            urlBuilder.Append("?limit=");
            urlBuilder.Append(HttpUtility.UrlEncode(Convert.ToString(limit)));

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.GET);
            ExecuteMethodAsync<DeliveryReportList>(requestData, callback);
        }

        /// <summary>
        /// Get delivery reports by Request Id </summary>
        /// <param name="requestId"> </param>
        /// <returns> DeliveryReportList </returns>
        public DeliveryReportList GetDeliveryReportsByRequestId(string requestId)
        {
            return GetDeliveryReportsByRequestId(requestId, 0);
        }

        /// <summary>
        /// Get delivery reports asynchronously by Request Id </summary>
        /// <param name="requestId"> </param>
        /// <param name="callback"> (mandatory) method to call after receiving delivery reports </param>
        public void GetDeliveryReportsByRequestIdAsync(string requestId, Action<DeliveryReportList, RequestException> callback)
        {
            GetDeliveryReportsByRequestIdAsync(requestId, 0, callback);
        }

        /// <summary>
        /// Get delivery reports by Request Id </summary>
        /// <param name="requestId"> </param>
        /// <param name="limit"> </param>
        /// <returns> DeliveryReportList </returns>
        public DeliveryReportList GetDeliveryReportsByRequestId(string requestId, int limit)
        {
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_OUTBOUND_URL_BASE)).Append("/requests/");
            urlBuilder.Append(HttpUtility.UrlEncode(requestId));
            urlBuilder.Append("/deliveryReports");
            urlBuilder.Append("?limit=");
            urlBuilder.Append(HttpUtility.UrlEncode(Convert.ToString(limit)));

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.GET);
            return ExecuteMethod<DeliveryReportList>(requestData);
        }

        /// <summary>
        /// Get delivery reports asynchronously by Request Id </summary>
        /// <param name="requestId"> </param>
        /// <param name="limit"> </param>
        /// <param name="callback"> (mandatory) method to call after receiving delivery reports </param>
        public void GetDeliveryReportsByRequestIdAsync(string requestId, int limit, Action<DeliveryReportList, RequestException> callback)
        {
            StringBuilder urlBuilder = (new StringBuilder(SMS_MESSAGING_OUTBOUND_URL_BASE)).Append("/requests/");
            urlBuilder.Append(HttpUtility.UrlEncode(requestId));
            urlBuilder.Append("/deliveryReports");
            urlBuilder.Append("?limit=");
            urlBuilder.Append(HttpUtility.UrlEncode(Convert.ToString(limit)));

            RequestData requestData = new RequestData(urlBuilder.ToString(), Method.GET);
            ExecuteMethodAsync<DeliveryReportList>(requestData, callback);
        }

        /// <summary>
        /// Add OneAPI PULL 'Delivery Reports' listener </summary>
        /// <param name="listener"> - (new DeliveryReportListener) </param>
        public void AddPullDeliveryReportListener(DeliveryReportListener listener)
        {
            if (listener == null)
            {
                return;
            }

            if (deliveryReportPullListenerList == null)
            {
                deliveryReportPullListenerList = new List<DeliveryReportListener>();
            }

            this.deliveryReportPullListenerList.Add(listener);
            this.StartDeliveryReportRetriever();
        }

        /// <summary>
        /// Add OneAPI PULL 'INBOUND Messages' listener
        /// Messages are pulled automatically depending on the 'inboundMessagesRetrievingInterval' client configuration parameter </summary>
        /// <param name="listener"> - (new InboundMessageListener) </param>
        public void AddPullInboundMessageListener(InboundMessageListener listener)
        {
            if (listener == null)
            {
                return;
            }

            if (inboundMessagePullListenerList == null)
            {
                inboundMessagePullListenerList = new List<InboundMessageListener>();
            }

            this.inboundMessagePullListenerList.Add(listener);
            this.StartInboundMessageRetriever();
        }

        /// <summary>
        /// Returns INBOUND Message PULL Listeners list
        /// </summary>
        public IList<InboundMessageListener> InboundMessagePullListeners
        {
            get
            {
                return inboundMessagePullListenerList;
            }
        }

        /// <summary>
        /// Returns Delivery Reports PULL Listeners list
        /// </summary>
        public IList<DeliveryReportListener> DeliveryReportPullListeners
        {
            get
            {
                return deliveryReportPullListenerList;
            }
        }

        /// <summary>
        /// Remove PULL Delivery Reports listeners and stop retriever
        /// </summary>
        public void RemovePullDeliveryReportListeners()
        {
            StopDeliveryReportRetriever();
            deliveryReportPullListenerList = null;
            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("PULL Delivery Report Listeners are successfully released.");
            }
        }

        /// <summary>
        /// Remove PULL INBOUND Messages listeners and stop retriever
        /// </summary>
        public void RemovePullInboundMessageListeners()
        {
            StopInboundMessageRetriever();
            inboundMessagePullListenerList = null;
            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("PULL Inbound Message Listeners are successfully released.");
            }
        }

        /// <summary> 
        /// Add OneAPI PUSH 'Delivery Status' Notifications listener  and start push server simulator </summary>
        /// <param name="listener"> - (new DeliveryStatusNotificationListener) </param>
        public void AddPushDeliveryStatusNotificationsListener(DeliveryStatusNotificationsListener listener)
        {
            if (listener == null)
            {
                return;
            }

            if (deliveryStatusNotificationPushListenerList == null)
            {
                deliveryStatusNotificationPushListenerList = new List<DeliveryStatusNotificationsListener>();
            }

            deliveryStatusNotificationPushListenerList.Add(listener);

            StartDlrStatusPushServerSimulator();

            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("Listener is successfully added, push server is started and is waiting for Delivery Status Notifications");
            }
        }

        /// <summary>
        /// Add OneAPI PUSH 'INBOUND Messages' Notifications listener and start push server simulator
        /// <param name="listener"> - (new InboundMessageNotificationsListener) </param>
        public void AddPushInboundMessageNotificationsListener(InboundMessageNotificationsListener listener)
        {
            if (listener == null)
            {
                return;
            }

            if (inboundMessagePushListenerList == null)
            {
                inboundMessagePushListenerList = new List<InboundMessageNotificationsListener>();
            }

            inboundMessagePushListenerList.Add(listener);

            StartInboundMessagesPushServerSimulator();

            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("Listener is successfully added, push server is started and is waiting for Inbound Messages Notifications");
            }
        }

        /// <summary>
        /// Returns Delivery Status Notifications PUSH Listeners list 
        /// </summary>
        public IList<DeliveryStatusNotificationsListener> DeliveryStatusPushNotificationsListeners
        {
            get
            {
                return deliveryStatusNotificationPushListenerList;
            }
        }

        /// <summary>
        /// Returns INBOUND Message Notifications PUSH Listeners list
        /// </summary>
        public IList<InboundMessageNotificationsListener> InboundMessagePushNotificationsListeners
        {
            get
            {
                return inboundMessagePushListenerList;
            }
        }

        /// <summary>
        /// Remove PUSH Delivery Reports Notifications listeners and stop server
        /// </summary>
        public void RemovePushDeliveryStatusNotificationsListeners()
        {
            StopDlrStatusPushServerSimulator();
            deliveryStatusNotificationPushListenerList = null;

            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("Delivery Status Notification Listeners are successfully removed.");
            }
        }

        /// <summary>
        /// Remove PUSH INBOUND Messages Notifications listeners and stop server
        /// </summary>
        public void RemovePushInboundMessageNotificationsListeners()
        {
            StopInboundMessagesPushServerSimulator();
            inboundMessagePushListenerList = null;

            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("Inbound Message Listeners are successfully removed.");
            }
        }
        //*************************SMSMessagingClientImpl private******************************************************************************************************************************************************
        /// <summary>
        /// START DLR Retriever
        /// </summary>
        private void StartDeliveryReportRetriever()
        {
            if (this.deliveryReportRetriever != null)
            {
                return;
            }

            this.deliveryReportRetriever = new DeliveryReportRetriever();
            int intervalMs = Configuration.DlrRetrievingInterval;
            this.deliveryReportRetriever.Start(intervalMs, this);

            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("Delivery Report Retriever is successfully started.");
            }
        }

        /// <summary>
        /// STOP DLR Retriever 
        /// </summary>
        private void StopDeliveryReportRetriever()
        {
            if (deliveryReportRetriever == null)
            {
                return;
            }

            deliveryReportRetriever.Stop();
            deliveryReportRetriever = null;

            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("Delivery Report Retriever is successfully stopped.");
            }
        }

        /// <summary>
        /// START INBOUND Message Retriever
        /// </summary>
        private void StartInboundMessageRetriever()
        {
            if (this.inboundMessageRetriever != null)
            {
                return;
            }

            this.inboundMessageRetriever = new InboundMessageRetriever();
            int intervalMs = Configuration.InboundMessagesRetrievingInterval;
            this.inboundMessageRetriever.Start(intervalMs, this);

            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("Inbound Messages Retriever is successfully started.");
            }
        }

        /// <summary>
        /// STOP INBOUND Message Retriever 
        /// </summary>
        private void StopInboundMessageRetriever()
        {
            if (inboundMessageRetriever == null)
            {
                return;
            }

            inboundMessageRetriever.Stop();
            inboundMessageRetriever = null;

            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("Inbound Messages Retriever is successfully stopped.");
            }
        }

        private void StartDlrStatusPushServerSimulator()
        {
            if (dlrStatusPushServerSimulator == null)
            {
                dlrStatusPushServerSimulator = new PushServerSimulator(this);
            }

            dlrStatusPushServerSimulator.Start(Configuration.DlrStatusPushServerPort);
        }

        private void StopDlrStatusPushServerSimulator()
        {
            if (dlrStatusPushServerSimulator != null)
            {
                dlrStatusPushServerSimulator.Stop();
            }
        }

        private void StartInboundMessagesPushServerSimulator()
        {
            if (inboundMessagesPushServerSimulator == null)
            {
                inboundMessagesPushServerSimulator = new PushServerSimulator(this);
            }

            inboundMessagesPushServerSimulator.Start(Configuration.InboundMessagesPushServerSimulatorPort);
        }

        private void StopInboundMessagesPushServerSimulator()
        {
            if (inboundMessagesPushServerSimulator != null)
            {
                inboundMessagesPushServerSimulator.Stop();
            }
        }
    }
}