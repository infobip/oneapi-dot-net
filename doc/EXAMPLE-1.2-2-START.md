    public void ProcessDeliveryNotification(HttpContext context)
    {
		// Get the JSON content of Parseco's request 
		string deliveryInfoNotificationJson = new StreamReader(context.Request.InputStream, System.Text.Encoding.UTF8).ReadToEnd();
		
		// Convert the JSON to a DeliveryInfoNotification object
		DeliveryInfoNotification deliveryInfoNotification =
                OneAPIBaseClientImpl.ConvertJsonToObject<DeliveryInfoNotification>(deliveryInfoNotificationJson, "deliveryInfoNotification");
