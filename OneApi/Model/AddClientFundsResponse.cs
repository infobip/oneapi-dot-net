using Newtonsoft.Json;

namespace OneApi.Model
{
	public class AddClientFundsResponse
	{
		[JsonProperty(PropertyName = "transactionId")]
		public int TransactionId;

		public override string ToString()
		{
			return "AddClientFundsResponse {TransactionId=" + TransactionId + "}";
		}
	}
}
