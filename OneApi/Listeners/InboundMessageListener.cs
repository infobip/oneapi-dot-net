using System;
using OneApi.Exceptions;
using OneApi.Model;

namespace OneApi.Listeners
{
    public class InboundMessageListener
    {
        private readonly Action<InboundSMSMessageList, RequestException> _onMessageReceived;

        public InboundMessageListener(Action<InboundSMSMessageList, Exception> onMessageReceived)
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
