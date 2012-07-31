using System;
using System.Text;
using Newtonsoft.Json;

namespace OneApi.Model
{

	/// <summary>
	/// Roaming contains the result of an attempt to get a single mobile terminal roaming status - either successfully or unsuccessfully
	/// </summary>
    [Serializable]
    public class RoamingAsync : Roaming
    {
        /// <summary>
        /// original detailed HLR data
        /// </summary>
        [JsonProperty(PropertyName = "extendedData")]
        public AsyncHLRExtendedData ExtendedData;

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

            buffer.Append(", extendedData={");
            if (ExtendedData != null)
            {
                buffer.Append(ExtendedData);
            }
            buffer.Append("}");

            return buffer.ToString();
        }
    }	
}