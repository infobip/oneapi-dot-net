
using System.Net;
using System.Threading;
using System;
using System.IO;
using System.Text;
using OneApi.Client.Impl;
using OneApi.Model;
using System.Net.Sockets;

public class PushServerSimulator
{
    private static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    private TcpListener listener = null;
    private Thread thread = null;
    private bool running = false;
    private SMSMessagingClientImpl smsMessagingImpl = null;
    private HLRClientImpl hlrClientImpl = null;
    private int port;

    public PushServerSimulator(SMSMessagingClientImpl smsMessagingImpl)
    {
        this.smsMessagingImpl = smsMessagingImpl;
    }

    public PushServerSimulator(HLRClientImpl hlrClientImpl)
    {
        this.hlrClientImpl = hlrClientImpl;
    }

    public void Start(int port)
    {
        if (listener != null && listener.Server.IsBound)
        {
            return;
        }

        this.port = port;

        IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, port);
        listener = new TcpListener(ipEnd);

        try
        {
            listener.Start();
            running = true;
            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("Push Server Simulator is successfully started on port " + port.ToString());
            }
        }
        catch (Exception e)
        {
            if (LOGGER.IsErrorEnabled)
            {
                LOGGER.Error("Error occured while trying to start Push Server Simulator on port " + port.ToString() + " . Message: " + e.Message);
            }
        }

        thread = new Thread(new ThreadStart(listen));
        thread.Start();
    }

    private void listen()
    {
        while (running)
        {
            Socket clientSock = listener.AcceptSocket();

            byte[] clientData = new byte[4096];
            int receivedBytesLen = clientSock.Receive(clientData);

            string receivedData = Encoding.UTF8.GetString(clientData, 0, receivedBytesLen);
            string[] arrReceivedData = System.Text.RegularExpressions.Regex.Split(receivedData, "\r\n\r\n");

            if (arrReceivedData.Length == 2)
            {
                processRequestData(arrReceivedData[1]); ;
            }

            if (clientSock != null)
            {
                try
                {
                    clientSock.Close();
                }
                catch (Exception e)
                {
                    if (LOGGER.IsErrorEnabled)
                    {
                        LOGGER.Error("Error occured while trying to close Push Server Simulator connection on port " + port.ToString() + ". Message: " + e.Message);
                    }
                }
            }
        }

        try
        {
            listener.Server.Close();
            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("Push Server Simulator on port " + port.ToString() + " is successfully stopped.");
            }
        }
        catch (Exception e)
        {
            if (LOGGER.IsErrorEnabled)
            {
                LOGGER.Error("Error occured while trying to stop Push Server Simulator on port " + port.ToString() + ". Message: " + e.Message);
            }
        }
    }

    private void processRequestData(String json)
    {
        try
        {
            if (json.Trim().Length > 0)
            {
                if (smsMessagingImpl != null)
                {
                    if (json.Contains("deliveryInfoNotification"))
                    {
                        DeliveryInfoNotification deliveryInfoNotification = smsMessagingImpl.ConvertJsonToDeliveryInfo(json);
                        if (smsMessagingImpl.DeliveryStatusPushNotificationsListeners != null)
                        {
                            for (int i = 0; i < smsMessagingImpl.DeliveryStatusPushNotificationsListeners.Count; i++)
                            {
                                smsMessagingImpl.DeliveryStatusPushNotificationsListeners[i].OnDeliveryStatusNotificationReceived(deliveryInfoNotification);
                            }
                        }
                    }
                    else if (json.Contains("inboundSMSMessage"))
                    {
                        if (smsMessagingImpl != null)
                        {
                            if (smsMessagingImpl.InboundMessagePushNotificationsListeners != null)
                            {
                                InboundSMSMessageList smsMessagesList = smsMessagingImpl.ConvertJsonToInboundSMSMessageList(json);
                                for (int i = 0; i < smsMessagingImpl.InboundMessagePushNotificationsListeners.Count; i++)
                                {
                                    smsMessagingImpl.InboundMessagePushNotificationsListeners[i].OnMessageReceived(smsMessagesList);
                                }
                            }
                        }
                    }
                }
                else if (hlrClientImpl != null)
                {
                    if (json.Contains("terminalRoamingStatusList"))
                    {
                        if (hlrClientImpl.HlrPushNotificationsListeners != null)
                        {
                            RoamingNotification roamingNotification = hlrClientImpl.ConvertJsonToRoamingNotification(json);
                            for (int i = 0; i < hlrClientImpl.HlrPushNotificationsListeners.Count; i++)
                            {
                                hlrClientImpl.HlrPushNotificationsListeners[i].OnHLRReceived(roamingNotification);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            if (LOGGER.IsErrorEnabled)
            {
                LOGGER.Error("Error occured while trying to process pushed JSON: " + json + ". Message: " + e.Message);
            }
        }
    }

    public void Stop()
    {
        running = false;
    }
}
