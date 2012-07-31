using System;
using OneApi.Model;

namespace OneApi.Listeners
{

	public class DeliveryReportListener
	{

        private readonly Action<DeliveryReport[], Exception> _onDeliveryReportReceived;

        public DeliveryReportListener(Action<DeliveryReport[], Exception> onDeliveryReportReceived)    
        {       
             _onDeliveryReportReceived = onDeliveryReportReceived;    
        }

        public void OnDeliveryReportReceived(DeliveryReport[] deliveryReports, Exception e) 
        {
            if (_onDeliveryReportReceived != null) 
            {
                _onDeliveryReportReceived(deliveryReports, e); 
            } 
        } 
	}
}