
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

    public PushServerSimulator(SMSMessagingClientImpl smsMessagingImpl)
    {
        this.smsMessagingImpl = smsMessagingImpl;
    }

    public PushServerSimulator(HLRClientImpl hlrClientImpl)
    {
        this.hlrClientImpl = hlrClientImpl;
    }

    public bool Running
    {
        get { return running; }
    }

    public void Start(int port)
    {
        if (listener != null && listener.Server.IsBound)
        {
            return;
        }

        IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, port);
        listener = new TcpListener(ipEnd);

        try
        {
            listener.Start();
            running = true;
            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("Push Server Simulator is successfully started");
            }

            thread = new Thread(new ThreadStart(listen));
            thread.Start();
        }
        catch (Exception e)
        {
            if (LOGGER.IsErrorEnabled)
            {
                LOGGER.Error("Error occured while trying to start Push Server Simulator. Message: " + e.Message);
            }
        }
    }

    private void listen()
    {
        while (running == true)
        {
            Socket clientSock = listener.AcceptSocket();

            byte[] clientData = new byte[4096];
            int receivedBytesLen = clientSock.Receive(clientData);

            string receivedData = Encoding.ASCII.GetString(clientData, 0, receivedBytesLen);
            string[] arrReceivedData = System.Text.RegularExpressions.Regex.Split(receivedData, "\r\n\r\n");

            if (arrReceivedData.Length == 2)
            {
                try
                {
                    string json = arrReceivedData[1];
                    if (json.Trim().Length > 0)
                    {
                        if (smsMessagingImpl != null)
                        {
                            if (json.Contains("deliveryInfoNotification"))
                            {
                                DeliveryInfoNotification deliveryInfoNotification = smsMessagingImpl.ConvertJsonToDeliveryInfo(json);
                                if (smsMessagingImpl.DeliveryStatusNotificationPushListeners != null)
                                {
                                    for (int i = 0; i < smsMessagingImpl.DeliveryStatusNotificationPushListeners.Count; i++)
                                    {
                                        smsMessagingImpl.DeliveryStatusNotificationPushListeners[i].OnDeliveryStatusNotificationReceived(deliveryInfoNotification);
                                    }
                                }
                            }
                            else if (json.Contains("inboundSMSMessage"))
                            {
                                if (smsMessagingImpl != null)
                                {
                                    if (smsMessagingImpl.InboundMessagePushListeners  != null)
                                    {
                                        InboundSMSMessageList smsMessagesList = smsMessagingImpl.ConvertJsonToInboundSMSMessageList(json);
                                        for (int i = 0; i < smsMessagingImpl.InboundMessagePushListeners.Count; i++)
                                        {
                                            smsMessagingImpl.InboundMessagePushListeners[i].OnMessageReceived(smsMessagesList);
                                        }
                                    }
                                }
                            }
                        }
                        else if (hlrClientImpl != null)
                        {
                            if (json.Contains("terminalRoamingStatusList"))
                            {
                                if (hlrClientImpl.HlrPushListeners != null)
                                {
                                    RoamingNotification roamingNotification = hlrClientImpl.ConvertJsonToRoamingNotification(json);
                                    for (int i = 0; i < hlrClientImpl.HlrPushListeners.Count; i++)
                                    {
                                        hlrClientImpl.HlrPushListeners[i].OnHLRReceived(roamingNotification);
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
                        LOGGER.Error("Error occured while trying to proccess pushed JSON. Message: " + e.Message);
                    }
                }
            }
        }

        try
        {
            listener.Server.Close();
            if (LOGGER.IsInfoEnabled)
            {
                LOGGER.Info("Push Server Simulator connection is successfully closed.");
            }
        }
        catch (Exception e)
        {
            if (LOGGER.IsErrorEnabled)
            {
                LOGGER.Error("Error occured while trying to stop Push Server Simulator. Message: " + e.Message);
            }
        }
    }

    public void Stop()
    {
        running = false;
    }
}
