using System;

namespace OneApi.Exceptions
{

    public class ConfigurationException : Exception 
	{
		private const long serialVersionUID = 1L;

		public ConfigurationException()
		{
		}

		public ConfigurationException(string s) : base(s)
		{
		}

        public ConfigurationException(string s, Exception e)
            : base(s, e)
		{
		}

		public ConfigurationException(Exception e) : base(e.Message, e)
		{
		}
	}

}