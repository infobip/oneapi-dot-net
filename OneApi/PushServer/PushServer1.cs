using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using OneApi.Listeners;
using Newtonsoft.Json.Linq;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.PushServer
{
    public class PushServer1
    {

        protected static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static Socket server = null;
        private static int port;
        private static SMSMessagingClientImpl smsMessagingImpl = null;
        private static HLRClientImpl hlrClientImpl = null;
        private static bool running = false;

        public static SMSMessagingClientImpl SmsMessagingImpl
        {
            set { smsMessagingImpl = value; }
        }

        public static HLRClientImpl HlrClientImpl
        {
            set { hlrClientImpl = value; }
        }

        public static void Start(int port)
        {
            PushServer1.port = port;

            if (server != null && server.IsBound)
            {
                return;
            }

            Thread listenThread = new Thread(new ThreadStart(StartServer));
            listenThread.Start();
            running = true;
        }

        private static void StartServer()
        {   
            try
            {           
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, port);
            
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                server.Bind(ipEnd);
                server.Listen(100);
             
                while (running)
                {
                    Socket clientSock = server.Accept();

                    byte[] clientData = new byte[4096];
                    int receivedBytesLen = clientSock.Receive(clientData);

                    string receivedData = Encoding.ASCII.GetString(clientData, 0, receivedBytesLen);
                    string[] arrReceivedData = System.Text.RegularExpressions.Regex.Split(receivedData, "\r\n\r\n");

                    if (arrReceivedData.Length == 2)
                    {
                        string json = arrReceivedData[1];

                        if (json.Trim().Length > 0)
                        {
                            if (json.Contains("deliveryInfoNotification"))
                            {
                                if (smsMessagingImpl != null)
                                {
                                    DeliveryInfoNotification deliveryInfoNotification = smsMessagingImpl.ConvertJsonToDeliveryInfo(json);
                                    if (smsMessagingImpl.DeliveryStatusNotificationPushListeners != null)
                                    {
                                        for (int i = 0; i < smsMessagingImpl.DeliveryStatusNotificationPushListeners.Count; i++)
                                        {
                                            smsMessagingImpl.DeliveryStatusNotificationPushListeners[i].OnDeliveryStatusNotificationReceived(deliveryInfoNotification, null);
                                        }
                                    }

                                }
                            }
                            else if (json.Contains("inboundSMSMessage"))
                            {
                                Console.WriteLine(json);

                                if (smsMessagingImpl != null)
                                {
                                    if (smsMessagingImpl.DeliveryStatusNotificationPushListeners != null)
                                    {
                                        InboundSMSMessageList smsMessagesList = smsMessagingImpl.ConvertJsonToInboundSMSMessageList(json);
                                        for (int i = 0; i < smsMessagingImpl.InboundMessagePushListeners.Count; i++)
                                        {
                                            smsMessagingImpl.InboundMessagePushListeners[i].OnMessageReceived(smsMessagesList, null);
                                        }
                                    }
                                }
                                else if (json.Contains("terminalRoamingStatusList"))
                                {
                                    if (hlrClientImpl != null)
                                    {
                                        if (hlrClientImpl.HlrPushListeners != null)
                                        {
                                            RoamingNotification roamingNotification = hlrClientImpl.ConvertJsonToRoamingNotification(json);
                                            for (int i = 0; i < smsMessagingImpl.DeliveryStatusNotificationPushListeners.Count; i++)
                                            {
                                                hlrClientImpl.HlrPushListeners[i].OnHLRReceived(roamingNotification, null);
                                            }
                                        }
                                    }
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
                LOGGER.Error(e.Message);  
                }

            //Stop();           

                Console.WriteLine(e.Message);
            } 
        }

        public static void Stop()
        {
            running = false;
            try
            {
                Thread.Sleep(100);
            }
            catch (Exception) { }

            if (server != null && server.IsBound)
            {
                server.Close();
                server = null;
            }
        }
    }
}
