namespace org.infobip.oneapi.model
{

	public class Currency
	{

		private int id;
		private string currencyName;
		private string symbol;
	//	private String decimalSymbol;
	//	private boolean used;
	//	private String currencyDecimalName;
	//	private String numericCode;
	//	private boolean usedByResellers;
	//	private boolean usedByAccounting;
	//	private boolean useOnlyNominalUnit;

		public Currency()
		{
		}

		public virtual string CurrencyName
		{
			set
			{
				this.currencyName = value;
			}
			get
			{
				return this.currencyName;
			}
		}

		public virtual string Symbol
		{
			set
			{
				this.symbol = value;
			}
			get
			{
				return this.symbol;
			}
		}

	//	public void setDecimalSymbol(String decimalSymbol){
	//		this.decimalSymbol = decimalSymbol;
	//	}
	//
	//	public void setUsed(boolean used){
	//		this.used = used;
	//	}
	//
	//	public void setCurrencyDecimalName(String currencyDecimalName){
	//		this.currencyDecimalName = currencyDecimalName;
	//	}
	//
	//	public void setNumericCode(String numericCode){
	//		this.numericCode = numericCode;
	//	}
	//
	//	public void setUsedByResellers(boolean usedByResellers){
	//		this.usedByResellers = usedByResellers;
	//	}
	//
	//	public void setUsedByAccounting(boolean usedByAccounting){
	//		this.usedByAccounting = usedByAccounting;
	//	}



	//	public String getDecimalSymbol(){
	//		return this.decimalSymbol;
	//	}
	//
	//	public boolean isUsed(){
	//		return this.used;
	//	}
	//
	//	public String getCurrencyDecimalName(){
	//		return this.currencyDecimalName;
	//	}
	//
	//	public String getNumericCode(){
	//		return this.numericCode;
	//	}
	//
	//	public boolean isUsedByResellers(){
	//		return this.usedByResellers;
	//	}
	//
	//	public boolean isUsedByAccounting(){
	//		return this.usedByAccounting;
	//	}

		public virtual int Id
		{
			set
			{
				this.id = value;
			}
			get
			{
				return this.id;
			}
		}


	//	public boolean isUseOnlyNominalUnit() {
	//		return useOnlyNominalUnit;
	//	}
	//
	//	public void setUseOnlyNominalUnit(boolean useOnlyNominalUnit) {
	//		this.useOnlyNominalUnit = useOnlyNominalUnit;
	//	}

	}
}