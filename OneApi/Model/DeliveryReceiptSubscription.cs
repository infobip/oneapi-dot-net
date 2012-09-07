using System;
using System.Text;
using Newtonsoft.Json;

namespace OneApi.Model
{

    /// <summary>
    /// Confirms the details of a successful request to subscribe to SMS delivery receipts
    /// </summary>
    [Serializable]
    public class DeliveryReceiptSubscription
    {
        /// <summary>
        /// inner class CallbackReference details details the URL of the page/ service to notify and additional data that will be sent 
        /// </summary>
        public class CallbackReference
        {

            /// <summary>
            /// return the user data that will be sent along with the callback notification
            /// </summary>
            /// 
            [JsonProperty(PropertyName = "callbackData")]
            public string CallbackData;

            /// <summary>
            /// return the URL of the page / service to send the notification to
            /// </summary>
            [JsonProperty(PropertyName = "notifyURL")]
            public string NotifyURL;

            /// <summary>
            /// default constructor
            /// </summary>
            public CallbackReference() { }

            /// <summary>
            /// alternate constructor setting both callbackData and notifyURL </summary>
            /// <param name="callbackData"> </param>
            /// <param name="notifyURL"> </param>
            public CallbackReference(string callbackData, string notifyURL)
            {
                CallbackData = callbackData;
                NotifyURL = notifyURL;
            }

            /// <summary>
            /// generate a textual representation of the CallbackReference  
            /// </summary>
            public override string ToString()
            {
                return "CallbackReference {callbackData=" + CallbackData
                    + ", notifyURL=" + NotifyURL + "}";
            }

        }

        /// <summary>
        /// get the reference to the inner callbackReference class - the notification URL and user supplied callback data </summary>
        /// <returns> CallbackReference </returns>
        [JsonProperty(PropertyName = "callbackReference")]
        public CallbackReference InnerCallbackReference;

        /// <summary>
        /// return resourceURL - a URL uniquely identifying this SMS delivery receipt subscription
        /// </summary>
        [JsonProperty(PropertyName = "resourceURL")]
        public string ResourceURL;

        /// <summary>
        /// generate a textual representation of the deliveryReceiptSubscription instance including nested elements and classes 
        /// </summary>
        public override string ToString()
        {
            return "DeliveryReceiptSubscription {callbackReference="
                    + InnerCallbackReference + ", resourceURL=" + ResourceURL + "}";
        }
    }
}