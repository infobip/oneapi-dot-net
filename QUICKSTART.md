### System overview
[Parseco](https://github.com/parseco/) is an [API](http://en.wikipedia.org/wiki/Application_programming_interface) implementation inspired by [OneApi](http://oneapi.gsma.com/api-list/) specification which is issued by the Global System for Mobile Communications Association. 
We felt the need to enrich the specification by adding a few fields in some requests and responses to make the API more comfortable for the developer.

Parseco API exposes the following mobile network functionalities:

 * <strong>Short message service</strong> (<strong>SMS</strong>) is the most widespread mobile network data application. The term stands for the service as well as the text message itself. We fully support [Unicode](http://en.wikipedia.org/wiki/Unicode) [UTF-16](http://en.wikipedia.org/wiki/UTF-16) character set so that you can use virtually any alphabet for composing your text. The only limitation for SMS messages is the message length which is 70 characters in case of a Unicode encoded message, or 160 characters in case the message is not Unicode encoded. If you want to send [longer messages](http://www.parseco.com/multipart-sms-messaging/) then the appropriate length is 67 per Unicode encoded message part and 153 characters per non Unicode encoded message part.
 * <strong>Unstructured supplementary services data</strong> (<strong>USSD</strong>) is mostly used for prepaid callback service, mobile-money services and menu-based information services. It is a connection-based data protocol which makes it more responsive than the message-based SMS. Connection-based means that a connection (session) is established and kept alive for the entire time during the communication. That is why it is sometimes used for WAP browsing. The length of the USSD message is up to 182 alphanumeric characters in length. Unfortunately, Unicode encoding is not supported.
 * <strong>[Number Context](http://www.infobip.com/services/number_context)</strong> Infobip's Number Context service communicates with a relevant mobile number's home network and can identify whether the subscribers handset is roaming on another network, currently active or has been disabled.
<br><sub>**\* HLR service has been renamed to Number Context service**</sub>

Other mobile network-related functionalities are due to be implemented.
In order to use Parseco API and gain access to [Infobip](http://www.infobip.com) mobile networks aggregator system you must [register](http://www.parseco.com/sign-up/) at the Parseco website.
In other words, by using Parseco .NET library you can [send SMS messages](http://www.parseco.com/#features-list) to **any** cell phone [around the globe](http://www.parseco.com/pricing-and-coverage/).

### Prerequisites
* You have installed the [.NET Framework 4.0](http://msdn.microsoft.com/en-us/library/vstudio/5a4x27ek(v=vs.100).aspx)
* You have downloaded the [Parseco OneAPI .NET library](https://github.com/parseco/oneapi-dot-net/tree/master/OneApi)


### General assumptions which must be fulfilled for all the following examples
 * You must have an active Internet connection.
 * You have satisfied the prerequisites and [signed up](http://www.parseco.com/sign-up/) at Parseco website. After sign-up, SMS message with the verification PIN will be sent to your cell phone.

<img id="quickstart-img-03" src="http://parseco.com/wp-content/themes/parseco/images/content/quickstart_03.png" title="Account verification" width="660" height="290" />

Input the four-digit PIN from the received SMS message in the verification box and press verify.
Congratulations on your successful registration - you can start using Parseco API! If you want, you can try out the [live demos](http://www.parseco.com/demos/) now.

### Assumptions which must be fulfilled for the examples with notification push
In every example two different architectural approaches are shown.
In the first scenario the mobile-originated (see example 3 for term explanation) information is returned to the (web) application that requested the operation.

In the second scenario the mobile-terminated information is still being sent by your (web) application, but the mobile-originated information is returned to an URL predefined by you via HTTP POST request. 
In other words, Parseco pushes the receiving inbound notifications (be it Number Context or delivery data, or messages) to your web application.

 * You must have your own web application in order to provide the URL for the Parseco push notifications.
 * You must register the URL mentioned above as notification URL at Parseco site [setup wizard](http://www.parseco.com/application/setup-wizard/)
 * Your inbound messages will be available for a period of 48 h after being received by our gateways.

For a given notification URL the [setup wizard](http://www.parseco.com/application/setup-wizard/) generates a pair of subscription number and keyword. The just generated subscription will be shown in the list below:
 
 * <strong>Id</strong> - The id of the subscription.
 * <strong>Address</strong> - Your GSM subscription number to which inbound messages are sent. **Prefix it with '+' prior to sending SMS message.**
 * <strong>Criteria</strong> - String which **must** be present at the start of the SMS message text, otherwise Parseco won't forward it to your code.
 * <strong>Notify URL</strong> - The registered URL to receive Parseco push notifications
 * <strong>Action</strong> - Action for subscription.

<img id="quickstart-img-02" src="http://parseco.com/wp-content/themes/parseco/images/content/quickstart_02.png" title="List of subscriptions" width="660" height="320" />

The "Notify URL" field is crucial. 
If it is present, then the approach with notification push is chosen, meaning that all your mobile-originated information will be sent to it via HTTP POST request.

If it is not present then the approach without notification push is chosen, meaning that all your mobile-originated information will be returned to the (web) application that requested the operation.
If you make changes, a "Save" button will appear in the "Action" column. If you want to apply the changes, press it.

### Notice
 * **After signup you won't be able to use any of our services for 2 to 5 minutes until the system propagates the changes.**
 * **Until you make your first payment the only GSM number to which you can send messages is the one tied to your Parseco account. It is meant for demo purposes only, so you have a 5 &euro; budget for testing, which roughly translates to 500 or less SMS messages, [depending upon your location](http://www.parseco.com/pricing-and-coverage/).**
 * All examples are [valid, runnable](http://sscce.org/) code snippets,  you can copy them to a new empty CS class, and replace the public static void Execute() method with the static void Main(string[] args). There may be other strings to replace, e.g. the username and password in the app.config file. After you have done that, you can run them.

### Example 1.1: Basic messaging (Hello world)

The first thing that needs to be done is to initialize the client with username and password in plaintext.
You are basically logging in to Parseco, so an exception will be thrown if the username and/or password are incorrect. The next step is to prepare the message:

 * <strong>sender address</strong> - value which will appear in the FROM field on the destination cell phone
 * <strong>address</strong> - GSM number of the destination cell phone
 * <strong>message</strong> - the contents of the SMS message

Sender address may be any string composed of printable characters but will it be delivered as such depends on the settings of the destination [network operator](http://en.wikipedia.org/wiki/Mobile_network_operator).
Therefore, our recommendation (but not a guarantee) is to use the [English](http://en.wikipedia.org/wiki/English_alphabet) [alphanumeric](http://en.wikipedia.org/wiki/Alphanumeric) character subset.

When you execute the send method it will return an object which is used to query the message delivery status.
These are possible states of the message once you have sent it: 
 
 * <strong>DeliveredToTerminal</strong> - the message has been delivered to the cell phone
 * <strong>DeliveredToNetwork</strong> - the message has been delivered to the cell phone network operator
 * <strong>MessageWaiting</strong> - message is pending delivery to the cell phone network operator
 * <strong>DeliveryImpossible</strong> - message will not be delivered
 * <strong>DeliveryUncertain</strong> - delivery cannot be confirmed due to network operator settings. It still may be delivered but we will never know it.

Now you are ready to send the message.

	private static string username = System.Configuration.ConfigurationManager.AppSettings.Get("Username");
    private static string password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
	private static string senderAddress = "Some sender";
	private static string message = "Hello world";
	private static string recipientAddress = "123456789";
	
	static void Main(string[] args)
	{	
    // Initialize Configuration object
    Configuration configuration = new Configuration(username, password);
    
    // Initialize SMSClient using the Configuration object
    SMSClient smsClient = new SMSClient(configuration);

    // Prepare Message Without Notify URL
    SMSRequest smsRequest = new SMSRequest(senderAddress, message, recipientAddress);

    // Send Message
    // Store request id because we can later query for the delivery status with it:
    SendMessageResult sendMessageResult = smsClient.SmsMessagingClient.SendSMS(smsRequest);

    // The client correlator is a unique identifier of this api call
    string clientCorrelator = sendMessageResult.ClientCorrelator;

    // Query for Delivery Status
    DeliveryInfoList deliveryInfoList = smsClient.SmsMessagingClient.QueryDeliveryStatus(senderAddress, clientCorrelator);
    string deliveryStatus = deliveryInfoList.DeliveryInfos[0].DeliveryStatus; 
    
    Console.WriteLine(deliveryStatus);

    }


### Example 1.2: Basic messaging (Hello world) with notification push
Set the notify URL when sending message:

	private static string username = System.Configuration.ConfigurationManager.AppSettings.Get("Username");
    private static string password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
	private static string senderAddress = "Some sender";
	private static string message = "Hello world";
	private static string recipientAddress = "123456789";
	private static string notifyUrl = "http://127.0.0.1:3000/"; // 3000=Default port for 'Delivery Info Notifications' server simulator
	
	static void Main(string[] args)
	{
    // Initialize Configuration object
    Configuration configuration = new Configuration(username, password);
    
    // Initialize SMSClient using the Configuration object
    SMSClient smsClient = new SMSClient(configuration);

    // Prepare Message With Notify URL
    SMSRequest smsRequest = new SMSRequest(senderAddress, message, recipientAddress);
    // The url where the delivery notification will be pushed:
    smsRequest.NotifyURL = notifyUrl;

    // Send Message
    // Store request id because we can later query for the delivery status with it:
    SendMessageResult sendMessageResult = smsClient.SmsMessagingClient.SendSMS(smsRequest);

    }


Parseco will send a HTTP POST request to this URL, and your web application must process it like this:

    public void ProcessDeliveryNotification(HttpContext context)
    {
		// Get the JSON content of Parseco's request 
		string deliveryInfoNotificationJson = new StreamReader(context.Request.InputStream, System.Text.Encoding.UTF8).ReadToEnd();
		
		// Convert the JSON to a DeliveryInfoNotification object
		DeliveryInfoNotification deliveryInfoNotification =
                OneAPIBaseClientImpl.ConvertJsonToObject<DeliveryInfoNotification>(deliveryInfoNotificationJson, "deliveryInfoNotification");

    Console.WriteLine("status: " + deliveryInfoNotification.DeliveryInfo.DeliveryStatus);
    Console.WriteLine("address: " + deliveryInfoNotification.DeliveryInfo.Address);
    Console.WriteLine("messageId: " + deliveryInfoNotification.DeliveryInfo.MessageId);
    Console.WriteLine("clientCorrelator: " + deliveryInfoNotification.DeliveryInfo.ClientCorrelator);
    Console.WriteLine("callback data: " + deliveryInfoNotification.CallbackData);

    }


Note that there is nothing stopping you from running both code snippets on the same host or within the same web application, but it is not necessary.

### Example 2.1: Cell phone roaming status (Number Context query)
When the cell phone is connected to a network other than his home operator network it is said to be [roaming](http://en.wikipedia.org/wiki/Roaming).
This is just a part of the information about a cell phone that can be obtained via a [Number Context](http://www.infobip.com/messaging/end_users/number_context_packages) query like in the example below.

    private static string username = System.Configuration.ConfigurationManager.AppSettings.Get("Username");
    private static string password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
    private static string address = "123456789";
	
	static void Main(string[] args)
	{

    // Initialize Configuration object 
    Configuration configuration = new Configuration(username, password);
    
    // Initialize SMSClient using the Configuration object
    SMSClient smsClient = new SMSClient(configuration);

    // Retrieve Roaming Status
    Roaming roaming = smsClient.HlrClient.QueryHLR(address); 
    
    Console.WriteLine(roaming);

    }


### Example 2.2: Cell phone roaming status (Number Context query) as notification push
Set the notify URL when sending message:

    private static string username = System.Configuration.ConfigurationManager.AppSettings.Get("Username");
    private static string password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
    private static string address = "123456789";
    private static string notifyUrl = "http://127.0.0.1:3002/"; // 3002=Default port for 'HLR Notifications' server simulator
	
	static void Main(string[] args)
	{

    // Initialize Configuration object 
    Configuration configuration = new Configuration(username, password);
    
    // Initialize SMSClient using the Configuration object
    SMSClient smsClient = new SMSClient(configuration);

    // Retrieve Roaming Status With Notify URL
    smsClient.HlrClient.QueryHLR(address, notifyUrl);

    }


Parseco will send a HTTP POST request to this URL, and your web application must process it like this:

    public void ProcessRoamingStatusNotification(HttpContext context)
    {
		// Get the JSON content of Parseco's request 
		string roamingStatusNotificationJson = new StreamReader(context.Request.InputStream, System.Text.Encoding.UTF8).ReadToEnd();
		
		// Convert the JSON to a RoamingNotification object
		RoamingNotification roamingNotification =
                OneAPIBaseClientImpl.ConvertJsonToObject<RoamingNotification>(roamingStatusNotificationJson, "roamingNotification");

    Console.WriteLine("servingMccMnc: " + roamingNotification.Roaming.ConnectionProfileServingMccMnc);
    Console.WriteLine("address: " + roamingNotification.Roaming.Address);
    Console.WriteLine("currentRoaming: " + roamingNotification.Roaming.CurrentRoaming);
    Console.WriteLine("resourceURL: " + roamingNotification.Roaming.ResourceURL);
    Console.WriteLine("retrievalStatus: " + roamingNotification.Roaming.RetrievalStatus);
    Console.WriteLine("callbackData: " + roamingNotification.Roaming.CallbackData);
    Console.WriteLine("extendedData: " + roamingNotification.Roaming.ExtendedData);
    Console.WriteLine("IMSI: " + roamingNotification.Roaming.ExtendedData.Imsi);
    Console.WriteLine("destinationAddres: " + roamingNotification.Roaming.ExtendedData.DestinationAddress);
    Console.WriteLine("originalNetworkPrefix: " + roamingNotification.Roaming.ExtendedData.OriginalNetworkPrefix);
    Console.WriteLine("portedNetworkPrefix: " + roamingNotification.Roaming.ExtendedData.PortedNetworkPrefix);

    }


Note that there is nothing stopping you from running both code snippets on the same host or within the same web application, but it is not necessary.

### Example 3.1: Process inbound messages (two way communication)
Two way communication with cell phone is also possible via Parseco.
The messages your application sends to cell phones are outbound or mobile-terminated messages.
It is a scenario much like in the first example.
The messages which your application receives from cell phones are inbound or mobile-originated messages.

In order to be able to receive inbound messages programmatically you must have a valid GSM subscription number.
For demo purposes, a valid 30-day trial GSM subscription number is tied to your Parseco account.
Our paid services include (info coming soon, mail to <a href="mailto:info@parseco.com">info@parseco.com</a>):

 * you may register a single subscription number 
 * you may register a single subscription number paired-up with a keyword of your choice
 * you may register a single subscription number paired-up with multiple keywords oy our choice
 * you may register for all or some of the above as many times as you like 

In order for the below example to work make sure that you have a subscription with no notify URL set at your [Parseco account](http://www.parseco.com/application/setup-wizard/).

    private static string username = System.Configuration.ConfigurationManager.AppSettings.Get("Username");
    private static string password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");

	static void Main(string[] args)
	{
	
    // Initialize Configuration object
    Configuration configuration = new Configuration(username, password);
    
    // Initialize SMSClient using the Configuration object
    SMSClient smsClient = new SMSClient(configuration);

    // Retrieve Inbound Messages
    InboundSMSMessageList inboundSMSMessageList = smsClient.SmsMessagingClient.GetInboundMessages();
    
    Console.WriteLine(inboundSMSMessageList);

    }


### Example 3.2: Process inbound messages (two way communication) as notification push
In order for the below example to work make sure that you have a subscription with a notify URL set at your [Parseco account](http://www.parseco.com/application/setup-wizard/). 
Of course, the notify URL must be mapped to your web application.

    public void ProcessInboundMessageNotification(HttpContext context)
    {
		// Get the JSON content of Parseco's request 
		string inboundMessageNotificationJson = new StreamReader(context.Request.InputStream, System.Text.Encoding.UTF8).ReadToEnd();
		
		// Convert the JSON to a InboundSMSMessageList object
		InboundSMSMessageList smsMessageList =
                OneAPIBaseClientImpl.ConvertJsonToObject<InboundSMSMessageList>(inboundMessageNotificationJson);

    foreach (InboundSMSMessage inboundSMSMessage in smsMessageList.InboundSMSMessage)
    {
        Console.WriteLine("dateTime: " + inboundSMSMessage.SubmitTime);
        Console.WriteLine("destinationAddress: " + inboundSMSMessage.DestinationAddress);
        Console.WriteLine("messageId: " + inboundSMSMessage.MessageId);
        Console.WriteLine("message: " + inboundSMSMessage.Message);
        Console.WriteLine("resourceURL: " + inboundSMSMessage.ResourceURL);
        Console.WriteLine("senderAddress: " + inboundSMSMessage.SenderAddress);
    }

    }

