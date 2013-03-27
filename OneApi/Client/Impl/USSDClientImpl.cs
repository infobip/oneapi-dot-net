using System;
using OneApi.Config;
using OneApi.Model;
using RestSharp;

namespace OneApi.Client.Impl
{
    class USSDClientImpl : OneAPIBaseClientImpl, USSDClient
    {
        private const string USSD_URL_BASE = "/ussd/outbound";

        public USSDClientImpl(Configuration configuration)
            : base(configuration)
        {
        }

        /// <summary>
        /// Send an USSD over OneAPI to one mobile terminal
        /// </summary>
        /// <param name="address"></param>
        /// <param name="message"></param>
        /// <returns> InboundSMSMessage </returns>
        public InboundSMSMessage SendMessage(String address, String message)
        {
            RequestData requestData = new RequestData(USSD_URL_BASE, Method.POST);
            requestData.FormParams = new USSDRequest(address, message);
            return ExecuteMethod<InboundSMSMessage>(requestData);
        }

        /// <summary>
        /// Stop USSD session
        /// </summary>
        /// <param name="address"></param>
        /// <param name="message"></param>
        public void StopSession(String address, String message)
        {
            RequestData requestData = new RequestData(USSD_URL_BASE, Method.POST);
            requestData.FormParams = new USSDRequest(address, message, true);
            ExecuteMethod(requestData);
        }
    }
}
