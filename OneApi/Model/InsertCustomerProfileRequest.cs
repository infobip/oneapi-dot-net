namespace org.oneapi.model
{

	/// 
	/// <summary>
	/// @author vavukovic
	/// 
	/// </summary>
	public class InsertCustomerProfileRequest
	{
		private string username;
		private string forename;
		private string surname;
		private string street;
		private string city;
		private string zipCode;
		private string telephone;
		private string gsm;
		private string fax;
		private string email;
		private string msn;
		private string skype;
		private string countryId;
		private string countryCode;
		private string timezoneId;
		private string primaryLanguageId;
		private string secondaryLanguageId;
		private bool enabled;

		public InsertCustomerProfileRequest()
		{
		}

		public InsertCustomerProfileRequest(string username, string countryId, string countryCode)
		{
		}

		public InsertCustomerProfileRequest(string username, string forename, string surname, string street, string city, string zipCode, string telephone, string gsm, string fax, string email, string msn, string skype, string countryId, string countryCode, string timezoneId, string primaryLanguageId, string secondaryLanguageId, bool enabled)
		{

			this.username = username;
			this.forename = forename;
			this.surname = surname;
			this.street = street;
			this.city = city;
			this.zipCode = zipCode;
			this.telephone = telephone;
			this.gsm = gsm;
			this.fax = fax;
			this.email = email;
			this.msn = msn;
			this.skype = skype;
			this.countryId = countryId;
			this.countryCode = countryCode;
			this.timezoneId = timezoneId;
			this.primaryLanguageId = primaryLanguageId;
			this.secondaryLanguageId = secondaryLanguageId;
			this.enabled = enabled;
		}

		public virtual string Username
		{
			get
			{
				return username;
			}
			set
			{
				this.username = value;
			}
		}


		public virtual string Forename
		{
			get
			{
				return forename;
			}
			set
			{
				this.forename = value;
			}
		}


		public virtual string Surname
		{
			get
			{
				return surname;
			}
			set
			{
				this.surname = value;
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


		public virtual string ZipCode
		{
			get
			{
				return zipCode;
			}
			set
			{
				this.zipCode = value;
			}
		}


		public virtual string Telephone
		{
			get
			{
				return telephone;
			}
			set
			{
				this.telephone = value;
			}
		}


		public virtual string Gsm
		{
			get
			{
				return gsm;
			}
			set
			{
				this.gsm = value;
			}
		}


		public virtual string Fax
		{
			get
			{
				return fax;
			}
			set
			{
				this.fax = value;
			}
		}


		public virtual string Email
		{
			get
			{
				return email;
			}
			set
			{
				this.email = value;
			}
		}


		public virtual string Msn
		{
			get
			{
				return msn;
			}
			set
			{
				this.msn = value;
			}
		}


		public virtual string Skype
		{
			get
			{
				return skype;
			}
			set
			{
				this.skype = value;
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


		public virtual string CountryCode
		{
			get
			{
				return countryCode;
			}
			set
			{
				this.countryCode = value;
			}
		}


		public virtual string TimezoneId
		{
			get
			{
				return timezoneId;
			}
			set
			{
				this.timezoneId = value;
			}
		}


		public virtual string PrimaryLanguageId
		{
			get
			{
				return primaryLanguageId;
			}
			set
			{
				this.primaryLanguageId = value;
			}
		}


		public virtual string SecondaryLanguageId
		{
			get
			{
				return secondaryLanguageId;
			}
			set
			{
				this.secondaryLanguageId = value;
			}
		}


		public virtual bool Enabled
		{
			get
			{
				return enabled;
			}
			set
			{
				this.enabled = value;
			}
		}


		public override string ToString()
		{
			return "AddCustomerProfileRequest {username=" + username + ", forename=" + forename + ", surname=" + surname + ", street=" + street + ", city=" + city + ", zipCode=" + zipCode + ", telephone=" + telephone + ", gsm=" + gsm + ", fax=" + fax + ", email=" + email + ", msn=" + msn + ", skype=" + skype + ", countryId=" + countryId + ", countryCode=" + countryCode + ", timezoneId=" + timezoneId + ", primaryLanguageId=" + primaryLanguageId + ", secondaryLanguageId=" + secondaryLanguageId + ", enabled=" + enabled + "}";
		}
	}

}