namespace org.oneapi.model
{

	/// <summary>
	/// @author mstipanov
	/// @since 19.06.12. 14:30
	/// </summary>
	public class SignupRequest
	{
		private string username;
		private string password;
		private string forename;
		private string surname;
		private string email;
		private string gsm;
		private string countryCode;
		private int timezoneId;
		private string captchaId;
		private string captchaAnswer;

		public SignupRequest()
		{
		}

		public SignupRequest(string username, string password, string forename, string surname, string email, string gsm, string countryCode, int timezoneId)
		{
			this.username = username;
			this.password = password;
			this.forename = forename;
			this.surname = surname;
			this.email = email;
			this.gsm = gsm;
			this.countryCode = countryCode;
			this.timezoneId = timezoneId;
		}

		public SignupRequest(string username, string password, string forename, string surname, string email, string gsm, string countryCode, int timezoneId, string captchaId, string captchaAnswer)
		{
			this.username = username;
			this.password = password;
			this.forename = forename;
			this.surname = surname;
			this.email = email;
			this.gsm = gsm;
			this.countryCode = countryCode;
			this.timezoneId = timezoneId;
			this.captchaId = captchaId;
			this.captchaAnswer = captchaAnswer;
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


		public virtual string Password
		{
			get
			{
				return password;
			}
			set
			{
				this.password = value;
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


		public virtual int TimezoneId
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


		public virtual string CaptchaId
		{
			get
			{
				return captchaId;
			}
			set
			{
				this.captchaId = value;
			}
		}


		public virtual string CaptchaAnswer
		{
			get
			{
				return captchaAnswer;
			}
			set
			{
				this.captchaAnswer = value;
			}
		}


		public override string ToString()
		{
			return "SignupRequest{" + "username='" + username + '\'' + ", password='" + password + '\'' + ", forename='" + forename + '\'' + ", surname='" + surname + '\'' + ", email='" + email + '\'' + ", gsm='" + gsm + '\'' + ", countryCode='" + countryCode + '\'' + ", timezoneId=" + timezoneId + ", captchaId='" + captchaId + '\'' + ", captchaAnswer='" + captchaAnswer + '\'' + '}';
		}
	}

}