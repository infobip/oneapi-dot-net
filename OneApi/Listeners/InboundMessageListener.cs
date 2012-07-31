using System;

namespace OneApi.Listeners
{

	using InboundSMSMessageList = OneApi.Model.InboundSMSMessageList;

    public class InboundMessageListener
    {

        private readonly Action<InboundSMSMessageList, Exception> _onMessageReceived;

        public InboundMessageListener(Action<InboundSMSMessageList, Exception> onMessageReceived)
        {
            _onMessageReceived = onMessageReceived;
        }

        public void OnMessageReceived(InboundSMSMessageList smsMessageList, Exception e)
        {
            if (_onMessageReceived != null)
            {
                _onMessageReceived(smsMessageList, e);
            }
        }
    }	
}
