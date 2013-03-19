    public void ProcessInboundMessageNotification(HttpContext context)
    {
		// Get the JSON content of Parseco's request 
		string inboundMessageNotificationJson = new StreamReader(context.Request.InputStream, System.Text.Encoding.UTF8).ReadToEnd();
		
		// Convert the JSON to a InboundSMSMessageList object
		InboundSMSMessageList smsMessageList =
                OneAPIBaseClientImpl.ConvertJsonToObject<InboundSMSMessageList>(inboundMessageNotificationJson);
