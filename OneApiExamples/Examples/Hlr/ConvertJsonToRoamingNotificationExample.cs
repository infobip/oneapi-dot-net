using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.Hlr
{

    public class ConvertJsonToRoamingNotificationExample
	{

        private const string JSON = "{\"terminalRoamingStatusList\":{\"roaming\":{\"address\":\"385915686022\",\"currentRoaming\":null,\"servingMccMnc\":{\"mcc\":\"219\",\"mnc\":\"02\"},\"resourceURL\":null,\"retrievalStatus\":\"Error\",\"extendedData\":{\"destinationAddress\":\"385915686022\",\"statusId\":5,\"doneTime\":1343382598560,\"pricePerMessage\":5.0,\"mccMnc\":\"21902\",\"servingMsc\":\"385951000000\",\"censoredServingMsc\":\"38595100\",\"gsmErrorCode\":0,\"originalNetworkName\":\"VIP-NET\",\"portedNetworkName\":\"TELE2\",\"servingHlr\":\"385951000010\",\"imsi\":\"219020000627769\",\"originalNetworkPrefix\":\"91\",\"originalCountryPrefix\":\"385\",\"originalCountryName\":\"Croatia                                           \",\"isNumberPorted\":true,\"portedNetworkPrefix\":\"95\",\"portedCountryPrefix\":\"385\",\"portedCountryName\":\"Croatia                                           \",\"numberInRoaming\":false},\"callbackData\":null}}}";

        public static void Execute()
        {
            Configuration configuration = new Configuration();
            SMSClient smsClient = new SMSClient(configuration);

            RoamingNotification roamingNotification = smsClient.HlrClient.ConvertJsonToRoamingNotification(JSON);
            Console.WriteLine("Roaming Notification: ", roamingNotification);   
        }
	}

}