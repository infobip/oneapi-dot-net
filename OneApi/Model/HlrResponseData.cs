using System;
using Newtonsoft.Json;
using OneApi.Model;
using OneApi.Converter;

namespace OneApi.Model
{
    [Serializable]
    public class HlrResponseData
    {
        [JsonProperty(PropertyName = "destinationAddress")]
        public string DestinationAddress;
        [JsonProperty(PropertyName = "submitTime")]
        [JsonConverter(typeof(CustomDateConverter))]
        public DateTime SubmitTime;
        [JsonProperty(PropertyName = "doneTime")]
        [JsonConverter(typeof(CustomDateConverter))]
        public DateTime DoneTime;
        [JsonProperty(PropertyName = "statusId")]
        public int StatusId;
        [JsonProperty(PropertyName = "pricePerMessage")]
        public double PricePerMessage;
        [JsonProperty(PropertyName = "mccMnc")]
        public string MccMnc;
        [JsonProperty(PropertyName = "mcc")]
        public string Mcc;
        [JsonProperty(PropertyName = "mnc")]
        public string Mnc;
        [JsonProperty(PropertyName = "servingMsc")]
        public string ServingMsc;
        [JsonProperty(PropertyName = "gsmErrorCode")]
        public int GsmErrorCode;
        [JsonProperty(PropertyName = "originalNetworkName")]
        public string OriginalNetworkName;
        [JsonProperty(PropertyName = "portedNetworkName")]
        public string PortedNetworkName;
        [JsonProperty(PropertyName = "roamingNetworkName")]
        public string RoamingNetworkName;
        [JsonProperty(PropertyName = "roamingCountryCode")]
        public string RoamingCountryCode;
        [JsonProperty(PropertyName = "roamingCountryName")]
        public string RoamingCountryName;
        [JsonProperty(PropertyName = "servingHlr")]
        public string ServingHlr;
        [JsonProperty(PropertyName = "originalNetworkPrefix")]
        public string OriginalNetworkPrefix;
        [JsonProperty(PropertyName = "originalCountryPrefix")]
        public string OriginalCountryPrefix;
        [JsonProperty(PropertyName = "originalCountryCode")]
        public string OriginalCountryCode;
        [JsonProperty(PropertyName = "originalCountryName")]
        public string OriginalCountryName;
        [JsonProperty(PropertyName = "roamingNetworkPrefix")]
        public string RoamingNetworkPrefix;
        [JsonProperty(PropertyName = "roamingCountryPrefix")]
        public string RoamingCountryPrefix;
        [JsonProperty(PropertyName = "isNumberPorted")]
        public bool IsNumberPorted;
        [JsonProperty(PropertyName = "portedNetworkPrefix")]
        public string PortedNetworkPrefix;
        [JsonProperty(PropertyName = "portedCountryPrefix")]
        public string PortedCountryPrefix;
        [JsonProperty(PropertyName = "portedCountryCode")]
        public string PortedCountryCode;
        [JsonProperty(PropertyName = "portedCountryName")]
        public string PortedCountryName;
        [JsonProperty(PropertyName = "roamingMccMnc")]
        public string RoamingMccMnc;
        [JsonProperty(PropertyName = "roamingMcc")]
        public string RoamingMcc;
        [JsonProperty(PropertyName = "roamingMnc")]
        public string RoamingMnc;
        [JsonProperty(PropertyName = "numberInRoaming")]
        public bool NumberInRoaming;
        [JsonProperty(PropertyName = "isNumberCorrect")]
        public bool IsNumberCorrect;
        [JsonProperty(PropertyName = "originalNetworkServiceProviderId")]
        public int OriginalNetworkServiceProviderId;
        [JsonProperty(PropertyName = "portedNetworkServiceProviderId")]
        public int PortedNetworkServiceProviderId;
        [JsonProperty(PropertyName = "roamingNetworkServiceProviderId")]
        public int RoamingNetworkServiceProviderId;
        [JsonProperty(PropertyName = "originalNetworkServiceProviderName")]
        public string OriginalNetworkServiceProviderName;
        [JsonProperty(PropertyName = "portedNetworkServiceProviderName")]
        public string PortedNetworkServiceProviderName;
        [JsonProperty(PropertyName = "roamingNetworkServiceProviderName")]
        public string RoamingNetworkServiceProviderName;
        [JsonProperty(PropertyName = "imsi")]
        public string Imsi;
        [JsonProperty(PropertyName = "censoredServingMsc")]
        public string CensoredServingMsc;

        public override string ToString()
        {
            return "HlrResponseData {destinationAddress=" + DestinationAddress
            + ", statusId=" + StatusId + ", submitTime=" + SubmitTime
            + ", doneTime=" + DoneTime + ", pricePerMessage="
            + PricePerMessage + ", mccMnc=" + MccMnc + ", mcc=" + Mcc
            + ", mnc=" + Mnc + ", servingMsc=" + ServingMsc
            + ", censoredServingMsc=" + CensoredServingMsc
            + ", gsmErrorCode=" + GsmErrorCode + ", originalNetworkName="
            + OriginalNetworkName + ", portedNetworkName="
            + PortedNetworkName + ", roamingNetworkName="
            + RoamingNetworkName + ", roamingCountryCode="
            + RoamingCountryCode + ", roamingCountryName="
            + RoamingCountryName + ", servingHlr=" + ServingHlr + ", imsi="
            + Imsi + ", originalNetworkPrefix=" + OriginalNetworkPrefix
            + ", originalCountryPrefix=" + OriginalCountryPrefix
            + ", originalCountryCode=" + OriginalCountryCode
            + ", originalCountryName=" + OriginalCountryName
            + ", roamingNetworkPrefix=" + RoamingNetworkPrefix
            + ", roamingCountryPrefix=" + RoamingCountryPrefix
            + ", isNumberPorted=" + IsNumberPorted
            + ", portedNetworkPrefix=" + PortedNetworkPrefix
            + ", portedCountryCode=" + PortedCountryCode
            + ", portedCountryPrefix=" + PortedCountryPrefix
            + ", portedCountryName=" + PortedCountryName
            + ", roamingMccMnc=" + RoamingMccMnc + ", roamingMcc="
            + RoamingMcc + ", roamingMnc=" + RoamingMnc
            + ", numberInRoaming=" + NumberInRoaming + ", isNumberCorrect="
            + IsNumberCorrect + ", originalNetworkServiceProviderId="
            + OriginalNetworkServiceProviderId
            + ", portedNetworkServiceProviderId="
            + PortedNetworkServiceProviderId
            + ", roamingNetworkServiceProviderId="
            + RoamingNetworkServiceProviderId
            + ", originalNetworkServiceProviderName="
            + OriginalNetworkServiceProviderName
            + ", portedNetworkServiceProviderName="
            + PortedNetworkServiceProviderName
            + ", roamingNetworkServiceProviderName="
            + RoamingNetworkServiceProviderName + "}";
        }
    }
}