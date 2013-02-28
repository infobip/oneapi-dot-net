namespace OneApi.Model
{

	public class Currency
	{
		public Currency()
		{
		}

        public string CurrencyName;
        public string Symbol;
        public int Id;

        public override string ToString()
        {
            return "Currency {currencyName=" + CurrencyName + ", symbol=" + Symbol + ", id=" + Id + "}";
        }
	}
}