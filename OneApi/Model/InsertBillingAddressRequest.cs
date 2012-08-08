namespace org.oneapi.model
{

	/// 
	/// <summary>
	/// @author vavukovic
	/// 
	/// </summary>
	public class InsertBillingAddressRequest
	{
		private string description;
		private string companyName;
		private string street;
		private string postCode;
		private string city;
		private string countryId;
		private string vatNumber;
		private bool? active;

		public InsertBillingAddressRequest()
		{
		}

		public InsertBillingAddressRequest(string description, string companyName, string street, string postCode, string city, string countryId, string vatNumber, bool? active)
		{

			this.description = description;
			this.companyName = companyName;
			this.street = street;
			this.postCode = postCode;
			this.city = city;
			this.countryId = countryId;
			this.vatNumber = vatNumber;
			this.active = active;
		}

		public virtual string Description
		{
			get
			{
				return description;
			}
			set
			{
				this.description = value;
			}
		}


		public virtual string CompanyName
		{
			get
			{
				return companyName;
			}
			set
			{
				this.companyName = value;
			}
		}


		public virtual string Street
		{
			get
			{
				return street;
			}
			set
			{
				this.street = value;
			}
		}


		public virtual string PostCode
		{
			get
			{
				return postCode;
			}
			set
			{
				this.postCode = value;
			}
		}


		public virtual string City
		{
			get
			{
				return city;
			}
			set
			{
				this.city = value;
			}
		}


		public virtual string CountryId
		{
			get
			{
				return countryId;
			}
			set
			{
				this.countryId = value;
			}
		}


		public virtual string VatNumber
		{
			get
			{
				return vatNumber;
			}
			set
			{
				this.vatNumber = value;
			}
		}


		public virtual bool? Active
		{
			get
			{
				return active;
			}
			set
			{
				this.active = value;
			}
		}


		public override string ToString()
		{
			return "AddBillingAddressRequest {description=" + description + ", companyName=" + companyName + ", street=" + street + ", postCode=" + postCode + ", city=" + city + ", countryId=" + countryId + ", vatNumber=" + vatNumber + ", active=" + active + "}";
		}
	}

}