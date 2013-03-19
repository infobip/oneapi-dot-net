	private static string username = System.Configuration.ConfigurationManager.AppSettings.Get("Username");
    private static string password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
	private static string senderAddress = "Some sender";
	private static string message = "Hello world";
	private static string recipientAddress = "123456789";
	private static string notifyUrl = "http://127.0.0.1:3000/"; // 3000=Default port for 'Delivery Info Notifications' server simulator
	
	static void Main(string[] args)
	{