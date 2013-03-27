using System;
using System.Collections.Generic;
using OneApi.Exceptions;
using OneApi.Listeners;
using OneApi.Model;

namespace OneApi.Client
{
	public interface SMSMessagingClient
	{
		/// <summary>
		/// Send an SMS to one or more mobile terminals using the customized SMS object </summary>
		/// <param name="sms"> - object containing data needed to be filled in order to send the SMS </param>
        /// <returns> SendMessageResult </returns>
        SendMessageResult SendSMS(SMSRequest sms);

        /// <summary>
        /// Send an SMS asynchronously over OneAPI to one or more mobile terminals using the customized 'SMS' object </summary>
        /// <param name="sms"> (mandatory) object containing data needed to be filled in order to send the SMS </param>
        /// <param name="callback"> (mandatory) method to call after receiving sent SMS response </param>
        void SendSMSAsync(SMSRequest smsRequest, Action<SendMessageResult, RequestException> callback);

		/// <summary>
		/// Query the delivery status for an SMS sent to one or more mobile terminals </summary>
		/// <param name="senderAddress"> (mandatory) is the address from which SMS messages are being sent. Do not URL encode this value prior to passing to this function </param>
		/// <param name="requestId"> (mandatory) contains the requestId returned from a previous call to the sendSMS function </param>
		/// <returns> DeliveryInfoList </returns>
		DeliveryInfoList QueryDeliveryStatus(string senderAddress, string requestId);

         /// <summary>
        /// Query the delivery status asynchronously over OneAPI for an SMS sent to one or more mobile terminals </summary>
        /// <param name="senderAddress"> (mandatory) is the address from which SMS messages are being sent. Do not URL encode this value prior to passing to this function </param>
        /// <param name="requestId"> (mandatory) contains the requestId returned from a previous call to the sendSMS function </param>
        /// <param name="callback"> (mandatory) method to call after receiving delivery status </param>
        void QueryDeliveryStatusAsync(string senderAddress, string requestId, Action<DeliveryInfoList, RequestException> callback);
 
        /// <summary>
        /// Convert JSON to Delivery Info Notification </summary>
        /// <returns> DeliveryInfoNotification </returns>
        DeliveryInfoNotification ConvertJsonToDeliveryInfoNotification(string json);

		/// <summary>
		/// Start subscribing to delivery status notifications over OneAPI for all your sent SMS </summary>
        /// <returns> string - Subscription Id </returns>
        string SubscribeToDeliveryStatusNotifications(SubscribeToDeliveryNotificationsRequest subscribeToDeliveryNotificationsRequest);

		/// <summary>
		/// Get delivery notifications subscriptions by sender address </summary>
		/// <param name="senderAddress"> </param>
		/// <returns> DeliveryReportSubscription[] </returns>
		DeliveryReportSubscription[] GetDeliveryNotificationsSubscriptionsBySender(string senderAddress);

		/// <summary>
		/// Get delivery notifications subscriptions by subscription id </summary>
		/// <param name="subscriptionId"> </param>
		/// <returns> DeliveryReportSubscription </returns>
		DeliveryReportSubscription GetDeliveryNotificationsSubscriptionById(string subscriptionId);

		/// <summary>
		/// Get delivery notifications subscriptions by for the current user </summary>
		/// <returns> DeliveryReportSubscription[] </returns>
		DeliveryReportSubscription[] GetDeliveryNotificationsSubscriptions();

		/// <summary>
		/// Stop subscribing to delivery status notifications for all your sent SMS </summary>
		/// <param name="subscriptionId"> (mandatory) contains the subscriptionId of a previously created SMS delivery receipt subscription </param>
		void RemoveDeliveryNotificationsSubscription(string subscriptionId);

		/// <summary>
		/// Get SMS messages sent to your Web application over OneAPI </summary>
		/// <returns> InboundSMSMessageList </returns>
		InboundSMSMessageList GetInboundMessages();
    
		/// <summary>
		/// Get SMS messages sent to your Web application </summary>
		/// <param name="maxBatchSize"> (mandatory) is the maximum number of messages to get in this request </param>
		/// <returns> InboundSMSMessageList </returns>
		/// <exception cref="InboundMessagesException">  </exception>
		InboundSMSMessageList GetInboundMessages(int maxBatchSize);

        /// <summary>
        /// Get asynchronously SMS messages sent to your Web application over OneAPI </summary>
        /// <param name="callback"> (mandatory) method to call after receiving inbound messages </param>
        void GetInboundMessagesAsync(Action<InboundSMSMessageList, RequestException> callback);

        /// <summary>
        /// Get asynchronously SMS messages sent to your Web application over OneAPI </summary>
        /// <param name="maxBatchSize"> (optional) is the maximum number of messages to get in this request </param>
        /// <param name="callback"> (mandatory) method to call after receiving inbound messages </param>
        void GetInboundMessagesAsync(int maxBatchSize, Action<InboundSMSMessageList, RequestException> callback);

		/// <summary>
		/// Start subscribing to notifications of SMS messages sent to your application over OneAPI </summary>
		/// <param name="subscribeToInboundMessagesRequest"> (mandatory) contains inbound messages subscription data </param>
        /// <returns> string - Subscription Id  </returns>
        string SubscribeToInboundMessagesNotifications(SubscribeToInboundMessagesRequest subscribeToInboundMessagesRequest);

        /// <summary>
        /// Convert JSON to Inbound SMS Message Notification </summary>
        /// <returns> InboundSMSMessageList </returns>
        InboundSMSMessageList ConvertJsonToInboundSMSMessageNotification(string json);

		 /// <summary>
		 /// Get inbound messages notifications subscriptions for the current user </summary>
		 /// <returns> MoSubscription[] </returns>
		MoSubscription[] GetInboundMessagesNotificationsSubscriptions(int page, int pageSize);


		/// <summary>
		/// Get inbound messages notifications subscriptions for the current user (Default values are used: page=1, pageSize=10) </summary>
		/// <returns> MoSubscription[] </returns>
		MoSubscription[] GetInboundMessagesNotificationsSubscriptions();

		/// <summary>
		/// Stop subscribing to message receipt notifications for all your received SMS </summary>
		/// <param name="subscriptionId"> (mandatory) contains the subscriptionId of a previously created SMS message receipt subscription </param>
		void RemoveInboundMessagesNotificationsSubscription(string subscriptionId);

        /// <summary>
        /// Get delivery reports </summary>
        /// <returns> DeliveryReportList </returns>
        DeliveryReportList GetDeliveryReports();

        /// <summary>
        /// Get delivery reports asynchronously</summary>
        /// <param name="callback"> (mandatory) method to call after receiving delivery reports </param>
        void GetDeliveryReportsAsync(Action<DeliveryReportList, RequestException> callback);

		/// <summary>
		/// Get delivery reports </summary>
		/// <param name="limit"> </param>
        /// <returns> DeliveryReportList </returns>
        DeliveryReportList GetDeliveryReports(int limit);

        /// <summary>
        /// Get delivery reports asynchronously</summary>
        /// <param name="limit"> </param>
        /// <param name="callback"> (mandatory) method to call after receiving delivery reports </param>
        void GetDeliveryReportsAsync(int limit, Action<DeliveryReportList, RequestException> callback);

        /// <summary>
        /// Get delivery reports by Request Id </summary>
        /// <param name="requestId"> </param>
        /// <returns> DeliveryReportList </returns>
        DeliveryReportList GetDeliveryReportsByRequestId(string requestId);

        /// <summary>
        /// Get delivery reports asynchronously by Request Id </summary>
        /// <param name="requestId"> </param>
        /// <param name="callback"> (mandatory) method to call after receiving delivery reports </param>
        void GetDeliveryReportsByRequestIdAsync(string requestId, Action<DeliveryReportList, RequestException> callback);

		/// <summary>
		/// Get delivery reports by Request Id </summary>
		/// <param name="requestId"> </param>
		/// <param name="limit"> </param>
        /// <returns> DeliveryReportList </returns>
        DeliveryReportList GetDeliveryReportsByRequestId(string requestId, int limit);

        /// <summary>
        /// Get delivery reports asynchronously by Request Id </summary>
        /// <param name="requestId"> </param>
        /// <param name="limit"> </param>
        /// <param name="callback"> (mandatory) method to call after receiving delivery reports </param>
        void GetDeliveryReportsByRequestIdAsync(string requestId, int limit, Action<DeliveryReportList, RequestException> callback);

		/// <summary>
		/// Add 'INBOUND Messages' listener
		/// </summary>
		/// <param name="listener"> - (new InboundMessageListener) </param>
		void AddPullInboundMessageListener(InboundMessageListener listener);

		/// <summary>
		/// Add 'Delivery Reports' listener. </summary>
		/// <param name="listener"> - (new DeliveryReportListener) </param>
		void AddPullDeliveryReportListener(DeliveryReportListener listener);

		/// <summary>
		/// Returns INBOUND Message Listeners list
		/// </summary>
		IList<InboundMessageListener> InboundMessagePullListeners {get;}

		/// <summary>
		/// Returns Delivery Reports Listeners list
		/// </summary>
		IList<DeliveryReportListener> DeliveryReportPullListeners {get;}

		/// <summary>
        /// Remove Delivery Reports listeners and stop retriever
		/// </summary>
		void RemovePullDeliveryReportListeners();

		/// <summary>
		/// Remove INBOUND Messages listeners and stop retriever
		/// </summary>
		void RemovePullInboundMessageListeners();

        /// <summary> 
        /// Add OneAPI PUSH 'Delivery Status' Notifications listener  and start push server simulator </summary>
        /// <param name="listener"> - (new DeliveryStatusNotificationListener) </param>
        void AddPushDeliveryStatusNotificationsListener(DeliveryStatusNotificationsListener listener);

        /// <summary>
        /// Add OneAPI PUSH 'INBOUND Messages' Notifications listener and start push server simulator
        /// <param name="listener"> - (new InboundMessageNotificationsListener) </param>
        void AddPushInboundMessageNotificationsListener(InboundMessageNotificationsListener listener);

        /// <summary>
        /// Returns Delivery Status Notifications PUSH Listeners list
        /// </summary>
        IList<DeliveryStatusNotificationsListener> DeliveryStatusPushNotificationsListeners { get;}

        /// <summary>
        /// Returns INBOUND Message Notifications PUSH Listeners list
        /// </summary>
        IList<InboundMessageNotificationsListener> InboundMessagePushNotificationsListeners { get;}

       /// <summary>
        /// Remove PUSH Delivery Reports Notifications listeners and stop server
        /// </summary>
        void RemovePushDeliveryStatusNotificationsListeners();

         /// <summary>
        /// Remove PUSH INBOUND Messages Notifications listeners and stop server
        /// </summary>
        void RemovePushInboundMessageNotificationsListeners();
	}

}