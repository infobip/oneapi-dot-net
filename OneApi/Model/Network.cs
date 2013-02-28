namespace OneApi.Model
{
    public class Network
    {
        public Network()
        {
        }

        public int Id { get; set; }
        private int CountryId { get; set; }
        private string Name { get; set; }
        private bool Visible { get; set; }
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
