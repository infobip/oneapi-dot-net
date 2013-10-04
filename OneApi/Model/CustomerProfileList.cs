using Newtonsoft.Json;

namespace OneApi.Model
{
	public class CustomerProfileList
	{
		[JsonProperty(PropertyName = "clients")]
		public CustomerProfile[] Clients;

	}
}
