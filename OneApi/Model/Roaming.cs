using System;
using System.Text;
using Newtonsoft.Json;

namespace OneApi.Model
{

	/// <summary>
	/// Roaming contains the result of an attempt to get a single mobile terminal roaming status - either successfully or unsuccessfully
	/// </summary>
	[Serializable]
	public class Roaming
	{
		/// <summary>
		/// return the MSISDN of the mobile terminal 
		/// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address;

		/// <summary>
		/// return the status of the roaming
		/// </summary>
        [JsonProperty(PropertyName = "currentRoaming")]
        public string CurrentRoaming;

		/// <summary>
		/// the inner class CurrentLocation contains the serving network country code/ network code 
		/// </summary>
		public class ServingMccMnc
		{
			/// <summary>
			/// return mobile country code
			/// </summary>
            [JsonProperty(PropertyName = "mcc")]
            public string Mcc;

			/// <summary>
			/// return mobile network code
			/// </summary>
            [JsonProperty(PropertyName = "mnc")]
            public string Mnc;

			/// <summary>
			/// utility constructor to create a Roaming.ServingMccMnc object with all fields set
			/// </summary>
			public ServingMccMnc(string mcc, string mnc)
			{
				Mcc = mcc;
				Mnc = mnc;
			}
		}

        /// <summary>
        /// in case the terminal was successfully contacted servingMccMnc contains the connection profile details
        /// </summary>
        [JsonProperty(PropertyName = "servingMccMnc")]
        public ServingMccMnc ConnectionProfileServingMccMnc;

        public void SetServingMccMnc(String value)
        {
            if (value != null && value.Length > 2)
            {
                ConnectionProfileServingMccMnc = new ServingMccMnc(value.Substring(0, 3), value.Substring(3));
            }
        }

		/// <summary>
		/// return the url
		/// </summary>
        [JsonProperty(PropertyName = "resourceURL")]
        public string ResourceURL;

		/// <summary>
        /// the response status with possible values: "Retrieved", "Error"
		/// </summary>
        private string retrievalStatus = "Retrieved";

        [JsonProperty(PropertyName = "retrievalStatus")]
		public string RetrievalStatus
		{
			get
			{
				return retrievalStatus;
			}
			set
			{
				this.retrievalStatus = value;
			}
		}
   
        /**
	    * custom provided data when pushing HLR to a customer's URL
	    */
        [JsonProperty(PropertyName = "callbackData")]
        public string CallbackData;

		/// <summary>
		/// generate a textual representation of the Roaming instance including all nested elements and classes 
		/// </summary>
        public override string ToString()
		{
			StringBuilder buffer = new StringBuilder();
			buffer.Append("address = ");
			buffer.Append(Address);

			buffer.Append(", currentRoaming = ");
			buffer.Append(CurrentRoaming);

			buffer.Append(", retrievalStatus = ");
			buffer.Append(RetrievalStatus);

            buffer.Append(", callbackData = ");
            buffer.Append(CallbackData);

			buffer.Append(", servingMccMnc={");

            if (ConnectionProfileServingMccMnc != null)
			{
				buffer.Append("mcc = ");
                buffer.Append(ConnectionProfileServingMccMnc.Mcc);
				buffer.Append(", mnc = ");
				buffer.Append(ConnectionProfileServingMccMnc.Mnc);
			}

			buffer.Append(", resourceURL = ");
			buffer.Append(ResourceURL);
			buffer.Append("}");

			return buffer.ToString();
		}
	}
}