    public void ProcessRoamingStatusNotification(HttpContext context)
    {
		// Get the JSON content of Parseco's request 
		string roamingStatusNotificationJson = new StreamReader(context.Request.InputStream, System.Text.Encoding.UTF8).ReadToEnd();
		
		// Convert the JSON to a RoamingNotification object
		RoamingNotification roamingNotification =
                OneAPIBaseClientImpl.ConvertJsonToObject<RoamingNotification>(roamingStatusNotificationJson, "roamingNotification");
