using System;
using OneApi.Model;

namespace OneApi.Listeners
{

    public class InboundMessageNotificationsListener
    {
        private readonly Action<InboundSMSMessageList> _onMessageReceived;

        public InboundMessageNotificationsListener(Action<InboundSMSMessageList> onMessageReceived)
        {
            _onMessageReceived = onMessageReceived;
        }

        public void OnMessageReceived(InboundSMSMessageList smsMessageList)
        {
            if (_onMessageReceived != null)
            {
                _onMessageReceived(smsMessageList);
            }
        }
    }	
}
