
using System.Net;
using System.Threading;
using System;
using System.IO;
using System.Text;
using OneApi.Client.Impl;
using OneApi.Model;

public class PushServerSimulator1
{
    protected static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    private HttpListener listener;
    private bool running;
    //private const string prefixes = "http://127.0.0.1:3000/";
    private SMSMessagingClientImpl smsMessagingImpl = null;
    private HLRClientImpl hlrClientImpl = null;

    public PushServerSimulator1(SMSMessagingClientImpl smsMessagingImpl)
    {
        this.smsMessagingImpl = smsMessagingImpl;
    }

    public PushServerSimulator1(HLRClientImpl hlrClientImpl)
    {
        this.hlrClientImpl = hlrClientImpl;
    }

    public void Start(int port)
    {
        if (listener != null && listener.IsListening)
        {
            return;
        }

       

        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = "netsh http add urlacl url=http://+:" + port.ToString() + "/ user=" + Environment.UserDomainName + "\\" + Environment.UserName;
        process.StartInfo = startInfo;
        process.Start();


        listener = new HttpListener();
        //listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
       

        try
        {
            //listener.Prefixes.Add("http://localhost:" + port.ToString() + "/");
            listener.Prefixes.Add("http://*:" + port.ToString() + "/");
            //listener.Prefixes.Add("http://ip:2006/test/");
            //hl.Prefixes.Add("http://*:7867/test/");

            listener.Start();
            //Console.ReadKey();

        }
        catch (Exception e)
        {
            //Console.WriteLine("Error!!!!!!!!!!!!!!");
            Console.ReadKey();
            throw e;
        }


        //Console.WriteLine("Started!!!!!!!!!!!!!!!!");
        //Console.ReadKey();

        running = true;

        Thread thread = new Thread(new ThreadStart(listen));
        thread.Start();
    }

    private void listen()

    {
        while (running)
        {
            IAsyncResult result = listener.BeginGetContext(new AsyncCallback(ListenerCallback), listener);
            result.AsyncWaitHandle.WaitOne();
        }

        listener.Close();
    }

    private void ListenerCallback(IAsyncResult result)
    {
        HttpListenerContext context = listener.EndGetContext(result);

        Stream stream = context.Request.InputStream;
    
        int read = 0;
        byte[] buffer = new byte[1024];
      
        read = stream.Read(buffer, 0, buffer.Length);
      
        string json = Encoding.ASCII.GetString(buffer, 0, read);

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
                    if (smsMessagingImpl.DeliveryStatusNotificationPushListeners != null)
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
                    for (int i = 0; i < smsMessagingImpl.DeliveryStatusNotificationPushListeners.Count; i++)
                    {
                        hlrClientImpl.HlrPushListeners[i].OnHLRReceived(roamingNotification);
                    }
                }
            }
        }
    }

    public void Stop()
    {
        running = false;
    }
}
