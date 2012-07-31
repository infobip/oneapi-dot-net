using System;
using OneApi.Model;

namespace OneApi.Listeners
{
	public class HLRNotificationsListener
	{
        private readonly Action<RoamingNotification> _onHLRReceived;

        public HLRNotificationsListener(Action<RoamingNotification> onHLRReceived)    
        {
            _onHLRReceived = onHLRReceived;    
        }

        public void OnHLRReceived(RoamingNotification roamingNotification) 
        {
            if (_onHLRReceived != null) 
            {
                _onHLRReceived(roamingNotification); 
            } 
        }   
	}
}