namespace OneApi.Model
{

	public class Currency
	{
        public string CurrencyName { get; set; }
        public string Symbol { get; set; }
        public int Id { get; set; }

        public Currency()
        {
        }

        public override string ToString()
        {
            return "Currency {currencyName=" + CurrencyName + ", symbol=" + Symbol + ", id=" + Id + "}";
        }
	}
}