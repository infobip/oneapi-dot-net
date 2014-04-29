using Newtonsoft.Json;

namespace OneApi.Model
{
	public class AddClientFundsRequest
	{
		[JsonProperty(PropertyName = "currencyCode")]
		public string currencyCode;

		[JsonProperty(PropertyName = "accountKey")]
		public string accountKey;

		[JsonProperty(PropertyName = "description")]
		public string description;

        // Yes, I know!
		[JsonProperty(PropertyName = "ammount")]
		public decimal ammount;

		public AddClientFundsRequest(string currencyCode, string accountKey, string description, decimal ammount)
		{
			this.currencyCode = currencyCode;
			this.accountKey = accountKey;
			this.description = description;
			this.ammount = ammount;
		}
	}
}
