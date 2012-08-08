namespace org.oneapi.model
{

	public class UpdateBillingAddressRequest : InsertBillingAddressRequest
	{
		private int id;

		public UpdateBillingAddressRequest() : base()
		{
		}

		public UpdateBillingAddressRequest(int id, string description, string companyName, string street, string postCode, string city, string countryId, string vatNumber, bool? active) : base(description, companyName, street, postCode, city, countryId, vatNumber, active)
		{


			this.id = id;
		}

		public virtual int Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}


		public override string ToString()
		{
			return "SaveBillingAddressRequest {id=" + id + ", description=" + Description + ", companyName=" + CompanyName + ", street=" + Street + ", postCode=" + PostCode + ", city=" + City + ", countryId=" + CountryId + ", vatNumber=" + VatNumber + ", active()=" + Active + "}";
		}
	}

}