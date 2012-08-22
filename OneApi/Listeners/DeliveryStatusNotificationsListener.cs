using System;
using OneApi.Model;

namespace OneApi.Listeners
{
    public class DeliveryStatusNotificationsListener 
    {
        private readonly Action<DeliveryInfoNotification> _onDeliveryStatusNotificationReceived;

        public DeliveryStatusNotificationsListener(Action<DeliveryInfoNotification> onDeliveryStatusNotificationReceived)
        {
            _onDeliveryStatusNotificationReceived = onDeliveryStatusNotificationReceived;
        }

        public void OnDeliveryStatusNotificationReceived(DeliveryInfoNotification deliveryInfoNotification)
        {
            if (_onDeliveryStatusNotificationReceived != null)
            {
                _onDeliveryStatusNotificationReceived(deliveryInfoNotification);
            }
        }
    }
}
