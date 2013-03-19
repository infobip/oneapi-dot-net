    private static string username = System.Configuration.ConfigurationManager.AppSettings.Get("Username");
    private static string password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
    private static string address = "123456789";
    private static string notifyUrl = "http://127.0.0.1:3002/"; // 3002=Default port for 'HLR Notifications' server simulator
	
	static void Main(string[] args)
	{
