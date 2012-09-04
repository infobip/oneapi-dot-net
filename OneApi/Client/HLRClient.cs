using System;
using OneApi.Model;
using OneApi.Listeners;
using System.Collections.Generic;
using OneApi.Exceptions;

namespace OneApi.Client
{

	public interface HLRClient
	{
        /// <summary>
        /// Query the customer’s roaming status for a single network-connected mobile device and get HLR to the specified notify url </summary>
		/// <param name="address"> (mandatory) mobile device number being queried </param>
		/// <param name="notifyURL"> (mandatory) URL to receive the roaming status asynchronously </param>
        /// <param name="clientCorrelator"> (optional) Active only if notifyURL is specified, otherwise ignored. Uniquely identifies this request. If there is a communication failure during the request, using the same clientCorrelator when retrying the request helps the operator to avoid call the same request twice. </param>
        /// <param name="callbackData"> (optional) Active only if notifyURL is specified, otherwise ignored. This is custom data to pass back in notification to notifyURL, so you can use it to identify the request or any other useful data, such as a function name. </param>
        void QueryHLR(string address, string notifyURL, string clientCorrelator, string callbackData);

        /// <summary>
        /// Query the customer’s roaming status for a single network-connected mobile device and get HLR to the specified notify url </summary>
		/// <param name="address"> (mandatory) mobile device number being queried </param>	
        /// <param name="notifyURL"> (mandatory) URL to receive the roaming status asynchronously </param>
        void QueryHLR(string address, string notifyURL);

		/// <summary>
        /// Query the customer’s roaming status for a single network-connected mobile device and get HLR as the response </summary>
		/// <param name="address"> (mandatory) mobile device number being queried </param>
        /// <returns> Roaming </returns>
        Roaming QueryHLR(string address);

        /// <summary>
        /// Query asynchronously the customer’s roaming status for a single network-connected mobile device and get HLR as the response </summary>
        /// <param name="address"> (mandatory) mobile device number being queried </param>
        /// <param name="callback"> (mandatory) method to call after receiving HLR response </param>
        void QueryHLRAsync(string address, Action<Roaming, RequestException> callback);

        /// <summary>
        /// Convert JSON to HLR Notification </summary>
        /// <returns> RoamingNotification </returns>
        RoamingNotification ConvertJsonToHLRNotification(string json);

		/// <summary>
		/// Start subscribing to HLR delivery notifications over OneAPI </summary>
		/// <param name="subscribeToHLRDeliveryNotificationsRequest"> </param>
        /// <returns> string - Subscription Id </returns>
		string SubscribeToHLRDeliveryNotifications(SubscribeToHLRDeliveryNotificationsRequest subscribeToHLRDeliveryNotificationsRequest);

		/// <summary>
		/// Get HLR delivery notifications subscriptions by subscription id </summary>
		/// <param name="subscriptionId"> </param>
		/// <returns> DeliveryReportSubscription[] </returns>
		DeliveryReportSubscription[] GetHLRDeliveryNotificationsSubscriptionsById(string subscriptionId);

		/// <summary>
		/// Stop subscribing to HLR delivery notifications over OneAPI </summary>
		/// <param name="subscriptionId"> (mandatory) contains the subscriptionId of a previously created HLR delivery receipt subscription
		/// return ResponseCode (integer) </param>
		void RemoveHLRDeliveryNotificationsSubscription(string subscriptionId);

         /// <summary>
        /// Add OneAPI PUSH 'HLR' Notifications listener and start push server simulator 
        /// <param name="listener"> - (new HLRNotificationsListener) </param>
        void AddPushHLRNotificationsListener(HLRNotificationsListener listener);

       /// <summary>
        /// Returns HLR PUSH Notifications Listeners list
        /// </summary>
        IList<HLRNotificationsListener> HlrPushNotificationsListeners { get;}

        /// <summary>
        /// Rmeove PUSH HLR Notifications listeners and stop server
        /// </summary>
        void RemovePushHLRNotificationsListeners();
	}

}