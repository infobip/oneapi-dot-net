using System;
using System.Collections.Generic;
using System.Threading;

namespace OneApi.Retrievers
{

    using SMSMessagingClientImpl =OneApi.Client.Impl.SMSMessagingClientImpl;
    using RequestException = OneApi.Exceptions.RequestException;
    using InboundMessageListener =OneApi.Listeners.InboundMessageListener;
    using InboundSMSMessageList = OneApi.Model.InboundSMSMessageList;

    public class InboundMessageRetriever
    {
        Timer timer = null;
        public void Start(long interval, SMSMessagingClientImpl smsMessagingImpl)
        {
            this.Stop();
           
            if (interval <= 0)
            {
                return;
            }

            PollerTask pollerTask = new PollerTask(smsMessagingImpl);
            TimerCallback tcb = pollerTask.Run;
            timer = new Timer(tcb, null, 2000, interval);
        }

        public void Stop()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
        }

        private class PollerTask
        {
            private SMSMessagingClientImpl smsMessagingImpl;

            public PollerTask(SMSMessagingClientImpl smsMessagingImpl)
            {
                this.smsMessagingImpl = smsMessagingImpl;
            }

            public void Run(Object stateInfo)
            {
                if ((smsMessagingImpl.InboundMessagePullListeners != null) &&
                    (smsMessagingImpl.InboundMessagePullListeners.Count > 0))
                {
                    try
                    {
                        InboundSMSMessageList smsMessageList = smsMessagingImpl.GetInboundMessages();
                        if ((smsMessageList != null) &&
                            (smsMessageList.InboundSMSMessage != null) &&
                            (smsMessageList.InboundSMSMessage.Length > 0))
                        {
                            FireMessageRetrieved(smsMessageList, null);
                        }

                    }
                    catch (RequestException e)
                    {
                        FireMessageRetrieved(null, e);
                    }
                }
            }

            private void FireMessageRetrieved(InboundSMSMessageList smsMessageList, RequestException e)
            {
                for (int i = 0; i < smsMessagingImpl.InboundMessagePullListeners.Count; i++)
                {
                    smsMessagingImpl.InboundMessagePullListeners[i].OnMessageReceived(smsMessageList, e);
                }
            }
        }
    }
}