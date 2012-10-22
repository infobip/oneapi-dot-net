using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneApi.Model;

namespace OneApi.Client
{
    public interface USSDClient
    {
        /// <summary>
        ///  Send an USSD over OneAPI to one  mobile terminal using the customized 'USSDRequest' object
        /// </summary>
        /// <param name="ussdRequest"> ussdRequest (mandatory) object containing data needed to be filled in order to send the USSD </param>
        InboundSMSMessage SendMessage(String address, String message);

        /// <summary>
        /// Stop USSD session
        /// </summary>
        /// <param name="address"></param>
        /// <param name="message"></param>
        void StopSession(String address, String message);
    }
}
