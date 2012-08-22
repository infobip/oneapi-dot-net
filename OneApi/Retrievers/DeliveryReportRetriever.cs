using System;
using System.Collections.Generic;
using System.Threading;

namespace OneApi.Retrievers
{

    using SMSMessagingClientImpl = OneApi.Client.Impl.SMSMessagingClientImpl;
    using RequestException = OneApi.Exceptions.RequestException;
    using DeliveryReportListener = OneApi.Listeners.DeliveryReportListener;
    using DeliveryReport = OneApi.Model.DeliveryReport;
    using OneApi.Model;

    public class DeliveryReportRetriever
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
                if ((smsMessagingImpl.DeliveryReportPullListeners != null) &&
                    (smsMessagingImpl.DeliveryReportPullListeners.Count > 0))
                {
                    try
                    {
                        DeliveryReportList deliveryReportList = smsMessagingImpl.GetDeliveryReports();
                        if ((deliveryReportList != null) &&
                            (deliveryReportList.DeliveryReports != null) &&
                            (deliveryReportList.DeliveryReports.Length > 0))
                        {
                            FireReportRetrieved(deliveryReportList, null); 
                        }
                    }
                    catch (RequestException e)
                    {
                        FireReportRetrieved(null, e);
                    }
                }
            }

            private void FireReportRetrieved(DeliveryReportList deliveryReportList, RequestException e)
            {
                for (int i = 0; i < this.smsMessagingImpl.DeliveryReportPullListeners.Count; i++)
                {
                    smsMessagingImpl.DeliveryReportPullListeners[i].OnDeliveryReportReceived(deliveryReportList, e);
                }
            }
        }
    }
}