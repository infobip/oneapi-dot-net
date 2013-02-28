namespace OneApi.Model
{
	public class AccountBalance
	{		
		public AccountBalance()
		{
		}

        public Currency Currency;
        public decimal Balance;

		public override string ToString()
		{
            return "AccountBalance {balance=" + Balance + ", currency=" + Currency + "}";
		}
	}
}