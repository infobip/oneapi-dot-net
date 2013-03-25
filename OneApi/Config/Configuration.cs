using System;
using System.IO;
using Newtonsoft.Json;
using OneApi.Exceptions;
using OneApi.Model;

namespace OneApi.Config
{
	public class Configuration
	{
        protected static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private const string DEFAULT_CONFIG_FILE = "client.cfg";

        /// <summary>
        /// Object containing 'OneAPI' Authentication data </summary>
        /// <returns> Authentication </returns>
        [JsonProperty(PropertyName = "authentication")]
        public Authentication Authentication { get; set; }

        /// <summary>
        /// Base URL containing host name and port of the OneAPI SMS server </summary>
        /// <returns> messagingBaseUrl </returns>
        [JsonProperty(PropertyName = "apiUrl")]
        public string ApiUrl { get; set; }

        /// <summary>
        /// Version of OneAPI SMS you are accessing (the default is the latest version supported by that server) </summary>
        /// <returns> versionOneAPISMS </returns>
        [JsonProperty(PropertyName = "versionOneAPISMS")]
        public int VersionOneAPISMS { get; set; }

        /// <summary>
        /// Interval to automatically pool inbounds messages in milliseconds </summary>
        /// <returns> inboundMessagesRetrievingInterval </returns>
        [JsonProperty(PropertyName = "inboundMessagesRetrievingInterval")]
        public int InboundMessagesRetrievingInterval { get; set; }

        /// <summary>
        /// Interval to automatically pool delivery reports in milliseconds </summary>
        /// <returns> dlrRetrievingInterval </returns>
        [JsonProperty(PropertyName = "dlrRetrievingInterval")]
        public int DlrRetrievingInterval { get; set; }

        /// <summary>
        /// Delivery Notification Status Push server port (default = 3000) </summary>
        /// <returns> dlrStatusPushServerSimulatorPort </returns>
        [JsonProperty(PropertyName = "dlrStatusPushServerSimulatorPort")]
        public int DlrStatusPushServerPort { get; set; }

        /// <summary>
        /// Inbound Messages Notifications Push server port (default = 3001) </summary>
        /// <returns> inboundMessagesPushServerSimulatorPort </returns>
        [JsonProperty(PropertyName = "inboundMessagesPushServerSimulatorPort")]
        public int InboundMessagesPushServerSimulatorPort { get; set; }

        /// <summary>
        /// Hlr Notifications Push server port (default = 3002) </summary>
        /// <returns> hlrPushServerSimulatorPort </returns>
        [JsonProperty(PropertyName = "hlrPushServerSimulatorPort")]
        public int HlrPushServerSimulatorPort { get; set; }
       
		/// <summary>
		/// Initialize configuration object
		/// </summary>
		public Configuration()
		{
            this.Authentication = new Authentication();
            this.ApiUrl = "https://api.parseco.com";
            this.VersionOneAPISMS = 1;
            this.InboundMessagesRetrievingInterval = 5000;
            this.DlrRetrievingInterval = 5000;
            this.DlrStatusPushServerPort = 3000;
            this.InboundMessagesPushServerSimulatorPort = 3001;
            this.HlrPushServerSimulatorPort = 3002;
		}

		/// <summary>
		/// Initialize Configuration object ((load data from the 'client.cfg' configuration file)) </summary>
		/// <param name="loadFromFile"> determines if data will be loaded from the default configuration file </param>
		public Configuration(bool loadFromFile) 
            : this()
		{
			if (loadFromFile)
			{
				Load();
			}
		}

		/// <summary>
        /// Initialize configuration object using the 'BASIC' Authentication credentials (to use 'IBSSO' Authentication you need to call 'CustomerProfileClient.Login()' method after client initialization) </summary>
        /// <param name="username"> - 'BASIC' Authentication user name </param>
        /// <param name="password"> - 'BASIC' Authentication password </param>
        public Configuration(string username, string password)
            : this()
		{
            this.Authentication.Username = username;
            this.Authentication.Password = password;
            this.Authentication.Type = OneApi.Model.Authentication.AuthType.BASIC;
		}

		/// <summary>
        /// Initialize configuration object using the 'OAuth' Authentication </summary>
		/// <param name="accessToken"> - 'OAuth' Authentication Access Token </param>
		public Configuration(string accessToken)
            : this()
		{
            this.Authentication.AccessToken = accessToken;
            this.Authentication.Type = OneApi.Model.Authentication.AuthType.OAUTH;
		}

		/// <summary>
        /// Initialize configuration object using the 'IBSSO' Authentication credentials </summary>
		/// <param name="messagingBaseUrl"> - Base URL containing host name and port of the OneAPI SMS server </param>
		/// <param name="versionOneAPISMS"> - Version of OneAPI SMS you are accessing (the default is the latest version supported by that server) </param>
        /// <param name="username"> - 'IBSSO' Authentication user name </param>
        /// <param name="password"> - 'IBSSO' Authentication password </param>
		public Configuration(string messagingBaseUrl, int versionOneAPISMS, string username, string password) : this(username, password)
		{
			this.ApiUrl = messagingBaseUrl;
			this.VersionOneAPISMS = versionOneAPISMS;
		}

		/// <summary>
		/// Initialize configuration object using the 'OAuth' Authentication </summary>
		/// <param name="messagingBaseUrl"> - Base URL containing host name and port of the OneAPI SMS server </param>
		/// <param name="versionOneAPISMS"> - Version of OneAPI SMS you are accessing (the default is the latest version supported by that server) </param>
		/// <param name="accessToken"> - 'OAuth' Authentication Access Token </param>
		public Configuration(string messagingBaseUrl, int versionOneAPISMS, string accessToken) : this(accessToken)
		{
			this.ApiUrl = messagingBaseUrl;
			this.VersionOneAPISMS = versionOneAPISMS;
		}

        /// <summary>
		/// Load data from the default configuration file (client.cfg)
		/// </summary>
        public void Load()
        {
            Load("");
        }

		/// <summary>
		/// Load data from the configuration file 
		/// </summary>
        public void Load(string configFilePath)
		{
			try
			{
                if (configFilePath.Trim().Length == 0) {
                    configFilePath = DEFAULT_CONFIG_FILE;
                }

                StreamReader sr = new StreamReader(configFilePath);
                string json = sr.ReadToEnd();
                sr.Close();

                Configuration tmpConfig = JsonConvert.DeserializeObject<Configuration>(json);

                Authentication = tmpConfig.Authentication;
                ApiUrl = tmpConfig.ApiUrl;
                VersionOneAPISMS = tmpConfig.VersionOneAPISMS;
                InboundMessagesRetrievingInterval = tmpConfig.InboundMessagesRetrievingInterval;
                DlrRetrievingInterval = tmpConfig.DlrRetrievingInterval;

				if (LOGGER.IsInfoEnabled)
				{
					LOGGER.Info("Data successfully loaded from '" + DEFAULT_CONFIG_FILE + "' configuration file.");
				}

			}
			catch (Exception e)
			{
				throw new ConfigurationException(e);
			}
		}

        /// <summary>
        /// Save data to the default configuration file (client.cfg)
		/// </summary>
        public void Save()
        {
            Save("");
        }

		/// <summary>
		/// Save data to the configuration file 
		/// </summary>
        public void Save(string configFilePath)
		{
			try
			{
                if (configFilePath.Trim().Length == 0)
                {
                    configFilePath = DEFAULT_CONFIG_FILE;
                }

                string json = JsonConvert.SerializeObject(this, Formatting.Indented); 
                StreamWriter sw = new StreamWriter(configFilePath); 
                sw.Write(json); 
                sw.Close(); 

				if (LOGGER.IsInfoEnabled)
				{
                    LOGGER.Info("Data successfully saved to '" + DEFAULT_CONFIG_FILE + "' configuration file.");
				}
			}
			catch (Exception e)
			{
				throw new ConfigurationException(e);
			}
		}
	}
}