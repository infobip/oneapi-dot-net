using Newtonsoft.Json;

namespace OneApi.Model
{
    public class Network
    {
        public Network()
        {
        }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "countryId")]
        private int CountryId { get; set; }

        [JsonProperty(PropertyName = "name")]
        private string Name { get; set; }

        [JsonProperty(PropertyName = "visible")]
        private bool Visible { get; set; }

        [JsonProperty(PropertyName = "nnc")]
        private string Nnc { get; set; }

        public override string ToString()
        {
            return "Network{" +
                    "id=" + Id +
                    ", countryId=" + CountryId +
                    ", name='" + Name + '\'' +
                    ", visible=" + Visible +
                    ", nnc=" + Nnc +
                    '}';
        }
    }
}
