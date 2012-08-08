namespace org.oneapi.model
{

	/// 
	/// <summary>
	/// @author vavukovic
	/// 
	/// </summary>
	public class UpdateCustomerProfileRequest : InsertCustomerProfileRequest
	{
		private int id;

		public UpdateCustomerProfileRequest() : base()
		{
		}

		public UpdateCustomerProfileRequest(int id, string username, string forename, string surname, string street, string city, string zipCode, string telephone, string gsm, string fax, string email, string msn, string skype, string countryId, string countryCode, string timezoneId, string primaryLanguageId, string secondaryLanguageId, bool enabled) : base(username, forename, surname, street, city, zipCode, telephone, gsm, fax, email, msn, skype, countryId, countryCode, timezoneId, primaryLanguageId, secondaryLanguageId, enabled)
		{


			this.id = id;
		}

		public UpdateCustomerProfileRequest(int id, string username, string countryId, string countryCode) : base(username, countryId, countryCode)
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
			return "SaveCustomerProfileRequest {id=" + id + ", username=" + Username + ", forename=" + Forename + ", surname=" + Surname + ", street=" + Street + ", city=" + City + ", zipCode=" + ZipCode + ", telephone=" + Telephone + ", gsm=" + Gsm + ", fax=" + Fax + ", email=" + Email + ", msn=" + Msn + ", skype=" + Skype + ", countryId=" + CountryId + ", countryCode=" + CountryCode + ", timezoneId=" + TimezoneId + ", primaryLanguageId=" + PrimaryLanguageId + ", secondaryLanguageId=" + SecondaryLanguageId + ", enabled=" + Enabled + "}";
		}
	}

}