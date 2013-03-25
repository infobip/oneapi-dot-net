namespace OneApi.Model
{
	public class AccountBalance
	{
        public Currency Currency { get; set; }
        public decimal Balance { get; set; }

        public AccountBalance()
        {
        }

		public override string ToString()
		{
            return "AccountBalance {balance=" + Balance + ", currency=" + Currency + "}";
		}
	}
}