using System;
using Newtonsoft.Json;

namespace OneApi.Model
{
    [Serializable]
    public class SyncHLRExtendedData : HlrResponseData
    {
        [JsonProperty(PropertyName = "submitTime")]
        public DateTime SubmitTime;

        [JsonProperty(PropertyName = "doneTime")]
        public DateTime DoneTime;

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
