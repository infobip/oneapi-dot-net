using System;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.Hlr
{

    /**
    * To run this example follow these 4 steps:
    *
    *  1.) Download 'Parseco C# library' - available at www.github.com/parseco   
    *
    *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project 
    *
    *  3.) Open 'Examples.ConvertJsonToHLRNotification' class 
    *  
    *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
    *       There you will enter the appropriate example number in the console and press 'Enter' key 
    *       on which the result will be displayed in the Console.
    *       
    **/

    public class ConvertJsonToHLRNotification
	{
        // Pushed 'HLR Notification' JSON example
        private const string JSON = "{\"terminalRoamingStatusList\":{\"roaming\":{\"address\":\"45534534\",\"currentRoaming\":null,\"servingMccMnc\":{\"mcc\":\"219\",\"mnc\":\"02\"},\"resourceURL\":null,\"retrievalStatus\":\"Error\",\"extendedData\":{\"destinationAddress\":\"54353\",\"statusId\":5,\"doneTime\":1343893501000,\"pricePerMessage\":5.0,\"mccMnc\":\"21902\",\"servingMsc\":\"543553\",\"censoredServingMsc\":\"5345\",\"gsmErrorCode\":0,\"originalNetworkName\":\"VIP-NET\",\"portedNetworkName\":\"TELE2\",\"servingHlr\":\"5435\",\"imsi\":\"219020000627769\",\"originalNetworkPrefix\":\"91\",\"originalCountryPrefix\":\"385\",\"originalCountryName\":\"Croatia                                           \",\"isNumberPorted\":true,\"portedNetworkPrefix\":\"95\",\"portedCountryPrefix\":\"385\",\"portedCountryName\":\"Croatia                                           \",\"numberInRoaming\":false},\"callbackData\":null}}}";

        public static void Execute()
        {
            Configuration configuration = new Configuration();
            SMSClient smsClient = new SMSClient(configuration);

            // example:on-roaming-status
            RoamingNotification roamingNotification = smsClient.HlrClient.ConvertJsonToHLRNotification(JSON);
            //----------------------------------------------------------------------------------------------------
            Console.WriteLine(roamingNotification);   
        }
	}
}