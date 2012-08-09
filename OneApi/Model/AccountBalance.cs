namespace org.infobip.oneapi.model
{
	public class AccountBalance
	{
		private const long serialVersionUID = 1L;		
		public AccountBalance() : base()
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