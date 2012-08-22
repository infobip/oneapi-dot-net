using System;
using OneApi.Model;
using OneApi.Exceptions;

namespace OneApi.Listeners
{

	public class DeliveryReportListener
	{

        private readonly Action<DeliveryReportList, RequestException> _onDeliveryReportReceived;

        public DeliveryReportListener(Action<DeliveryReportList, RequestException> onDeliveryReportReceived)    
        {       
             _onDeliveryReportReceived = onDeliveryReportReceived;    
        }

        public void OnDeliveryReportReceived(DeliveryReportList deliveryReportList, RequestException e) 
        {
            if (_onDeliveryReportReceived != null) 
            {
                _onDeliveryReportReceived(deliveryReportList, e); 
            } 
        } 
	}
}