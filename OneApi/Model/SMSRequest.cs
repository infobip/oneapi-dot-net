using Newtonsoft.Json;
using System.ComponentModel;

namespace OneApi.Model
{
    public class SMSRequest
    {
        private string senderAddress = null;
        private string[] address = null;
        private string message = "";
        private string clientCorrelator = null;
        private string notifyURL = null;
        private string senderName = null;
        private string callbackData = null;
        private Language language = null;

        public SMSRequest()
        {
        }

        /// <summary>
        /// Initialize SMSRequest object using mandatory parameters </summary>
        /// <param name="senderAddress"> is the address to whom a responding SMS may be sent </param>
        /// <param name="recipientAddress"> contains one or more addresses for end user ID to send to </param>
        /// <param name="message"> contains the message text to send </param>
        public SMSRequest(string senderAddress, string message, params string[] recipientAddress)
        {
            this.senderAddress = senderAddress;
            this.message = message;
            this.address = recipientAddress;
        }

        /// <summary>
        /// Initialize SMSRequest object using mandatory and optional parameters </summary>
        /// <param name="senderAddress"> is the address to whom a responding SMS may be sent </param>
        /// <param name="recipientAddress"> contains one or more addresses for end user ID to send to </param>
        /// <param name="message"> contains the message text to send </param>
        /// <param name="clientCorrelator"> uniquely identifies this create MMS request. If there is a communication failure during the request, using the same clientCorrelator when retrying the request allows the operator to avoid sending the same MMS twice. </param>
        /// <param name="notifyURL"> is the URL to which you would like a notification of delivery sent </param>
        /// <param name="senderName"> is the name to appear on the user's terminal as the sender of the message </param>
        /// <param name="callbackData"> will be passed back to the notifyURL location, so you can use it to identify the message the receipt relates to (or any other useful data, such as a function name) </param>
        public SMSRequest(string senderAddress, string message, string clientCorrelator, string notifyURL, string senderName, string callbackData, params string[] recipientAddress)
        {
            this.senderAddress = senderAddress;
            this.message = message;
            this.clientCorrelator = clientCorrelator;
            this.notifyURL = notifyURL;
            this.senderName = senderName;
            this.callbackData = callbackData;
            this.address = recipientAddress;
        }

        /// <summary>
        /// (mandatory) is the address to whom a responding SMS may be sent </summary>
        /// <returns> senderAddress </returns>
        /// 
        [DisplayName("senderAddress")]
        [JsonProperty("senderAddress")]
        public virtual string SenderAddress
        {
            get
            {
                return senderAddress;
            }
            set
            {
                this.senderAddress = value;
            }
        }

        /// <summary>
        /// (mandatory) contains one address for end user ID to send to </summary>
        /// <returns> recipientsAddress </returns>
        [DisplayName("address")]
        [JsonProperty("address")]
        public virtual string[] Address
        {
            get
            {
                return address;
            }
            set
            {
                this.address = value;
            }
        }

        /// <summary>
        /// (mandatory) contains the message text to send
        /// @return
        /// </summary>
        [DisplayName("message")]
        [JsonProperty("message")]
        public virtual string Message
        {
            get
            {
                return message;
            }
            set
            {
                this.message = value;
            }
        }

        /// <summary>
        /// (optional) uniquely identifies this create MMS request. If there is a communication failure during the request, using the same clientCorrelator when retrying the request allows the operator to avoid sending the same MMS twice. </summary>
        /// <returns> clientCorrelator </returns>
        [DisplayName("clientCorrelator")]
        [JsonProperty("clientCorrelator")]
        public virtual string ClientCorrelator
        {
            get
            {
                return clientCorrelator;
            }
            set
            {
                this.clientCorrelator = value;
            }
        }

        /// <summary>
        /// (optional) is the URL to which you would like a notification of delivery sent </summary>
        /// <returns> notifyURL </returns>
        /// 
        [DisplayName("notifyURL")]
        [JsonProperty("notifyURL")]
        public virtual string NotifyURL
        {
            get
            {
                return notifyURL;
            }
            set
            {
                this.notifyURL = value;
            }
        }

        /// <summary>
        /// (optional) is the name to appear on the user's terminal as the sender of the message </summary>
        /// <returns> senderName </returns>

        [DisplayName("senderName")]
        [JsonProperty("senderName")]
        public virtual string SenderName
        {
            get
            {
                return senderName;
            }
            set
            {
                this.senderName = value;
            }
        }

        /// <summary>
        /// (optional) will be passed back to the notifyURL location, so you can use it to identify the message the receipt relates to (or any other useful data, such as a function name) </summary>
        /// <param name="callbackData"> </param>
        [DisplayName("callbackData")]
        [JsonProperty("callbackData")]
        public virtual string CallbackData
        {
            set
            {
                this.callbackData = value;
            }
            get
            {
                return callbackData;
            }
        }

        /// <summary>
        /// (optional) if using Turkish, Spanish or Portuguese languages.
        /// Be aware thar NLI information is defined in User Data Header (UDH), which reduces the available message length by 5 characters.
        /// <see cref="http://en.wikipedia.org/wiki/GSM_03.38"/>
        /// </summary>
        /// <param name="languageCode"> </param>
        [DisplayName("language")]
        [JsonProperty("language")]
        public Language Language
        {
            set
            {
                this.language = value;
            }
            get
            {
                return language;
            }
        }
    }
}