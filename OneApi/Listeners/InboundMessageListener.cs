using System;
using OneApi.Model;
using OneApi.Exceptions;

namespace OneApi.Listeners
{

    public class InboundMessageListener
    {

        private readonly Action<InboundSMSMessageList, RequestException> _onMessageReceived;

        public InboundMessageListener(Action<InboundSMSMessageList, RequestException> onMessageReceived)
        {
            _onMessageReceived = onMessageReceived;
        }

        public void OnMessageReceived(InboundSMSMessageList smsMessageList, RequestException e)
        {
            if (_onMessageReceived != null)
            {
                _onMessageReceived(smsMessageList, e);
            }
        }
    }	
}
