using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace OneApi.Model
{

    /// <summary>
    /// Contains the detail of a request to obtain delivery information for SMS messages sent via the OneAPI server
    /// </summary>

    [Serializable]
    public class DeliveryInfoList
    {
        /// <summary>
        /// The inner class DeliveryInfo contains pairings of the recipient address and a textual delivery status
        /// </summary>  
        public class DeliveryInfo
        {
            /// <summary>
            /// The address of the recipient (normally MSISDN).
            /// Return the address of the recipient (normally MSISDN).
            /// </summary>
            [JsonProperty(PropertyName = "address")]
            public string Address;

            /// <summary>
            /// Delivery status may be one of
            /// "DeliveredToTerminal", successful delivery to Terminal.
            /// "DeliveryUncertain", delivery status unknown: e.g. because it was handed off to another network.
            /// "DeliveryImpossible", unsuccessful delivery; the message could not be delivered before it expired.
            /// "MessageWaiting" , the message is still queued for delivery. This is a temporary state, pending transition to one of the preceding states.
            /// "DeliveredToNetwork", successful delivery to the network enabler responsible for routing the MMS
            ///  Return the delivery status for this recipient
            /// </summary>
            [JsonProperty(PropertyName = "deliveryStatus")]
            public string DeliveryStatus;

            [JsonProperty(PropertyName = "messageId")]
            public string MessageId;

            [JsonProperty(PropertyName = "clientCorrelator")]
            public string ClientCorrelator;

            /// <summary>
            /// default constructor
            /// </summary>
            public DeliveryInfo() { }

            /// <summary>
            /// utility constructor to create a DeliveryInfo instance with all fields set </summary>
            /// <param name="address"> </param>
            /// <param name="deliveryStatus"> </param>
            public DeliveryInfo(string address, string deliveryStatus, string messageId, string clientCorrelator)
            {
                Address = address;
                DeliveryStatus = deliveryStatus;
                MessageId = messageId;
                ClientCorrelator = clientCorrelator;
            }

            /// <summary>
            /// generate a textual representation of the DeliveryInfo contents 
            /// </summary>
            public override string ToString()
            {
                return "DeliveryInfo {address=" + Address + ", deliveryStatus="
                        + DeliveryStatus + "}";
            }
        }

        /// <summary>
        /// return the array of deliveryInfo pairs of address/ deliveryStatus
        /// </summary>
        [JsonProperty(PropertyName = "deliveryInfo")]
        public IList<DeliveryInfo> DeliveryInfos;

        /// <summary>
        /// return resourceURL containing a URL uniquely identifying this DeliveryInfoList request
        /// </summary>
        [JsonProperty(PropertyName = "resourceURL")]
        public string ResourceURL;

        /// <summary>
        /// generate a textual representation of the DeliveryInfoList instance including nested elements and classes 
        /// </summary>  
        public override string ToString()
        {
            return "DeliveryInfoList {deliveryInfos=" + DeliveryInfos
                    + ", resourceURL=" + ResourceURL + "}";
        }
    }
}