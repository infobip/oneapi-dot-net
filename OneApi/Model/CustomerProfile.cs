using System;
using Newtonsoft.Json;

namespace OneApi.Model
{
    [Serializable]
    public class CustomerProfile
    {
        [ObsoleteAttribute]
        [JsonProperty(PropertyName = "id")]
        public int Id;

        [JsonProperty(PropertyName = "username")]
        public string Username;

        [JsonProperty(PropertyName = "forename")]
        public string Forename;

        [JsonProperty(PropertyName = "surname")]
        public string Surname;

        [JsonProperty(PropertyName = "street")]
        public string Street;

        [JsonProperty(PropertyName = "city")]
        public string City;

        [JsonProperty(PropertyName = "zipCode")]
        public string ZipCode;

        [JsonProperty(PropertyName = "telephone")]
        public string Telephone;

        [JsonProperty(PropertyName = "gsm")]
        public string Gsm;

        [JsonProperty(PropertyName = "fax")]
        public string Fax;

        [JsonProperty(PropertyName = "email")]
        public string Email;

        [JsonProperty(PropertyName = "msn")]
        public string Msn;

        [JsonProperty(PropertyName = "skype")]
        public string Skype;

        [JsonProperty(PropertyName = "countryId")]
        public int CountryId;

        [JsonProperty(PropertyName = "timezoneId")]
        public int TimezoneId;

        [JsonProperty(PropertyName = "primaryLanguageId")]
        public int PrimaryLanguageId;

        [JsonProperty(PropertyName = "secondaryLanguageId")]
        public int SecondaryLanguageId;

        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled;

        [JsonProperty(PropertyName = "key")]
        public string Key;

        [JsonProperty(PropertyName = "accountKey")]
        public string AccountKey;

        [JsonProperty(PropertyName = "canSendTraffic")]
        public bool CanSendTraffic;

        [JsonProperty(PropertyName = "locked")]
        public bool Locked;

        [JsonProperty(PropertyName = "url")]
        public string Url;

        [JsonProperty(PropertyName = "accountId")]
        public string AccountId;

        public override string ToString()
        {
            return "CustomerProfile {accountId=" + AccountId + ", username=" + Username
                    + ", forename=" + Forename + ", surname=" + Surname
                    + ", street=" + Street + ", city=" + City + ", zipCode="
                    + ZipCode + ", telephone=" + Telephone + ", gsm=" + Gsm
                    + ", fax=" + Fax + ", email=" + Email + ", msn=" + Msn
                    + ", skype=" + Skype + ", countryId=" + CountryId + ", timezoneId=" + TimezoneId
                    + ", primaryLanguageId="
                    + PrimaryLanguageId + ", secondaryLanguageId="
                    + SecondaryLanguageId + ", enabled=" + Enabled +
                    ", key=" + Key + ", accountKey=" + AccountKey + ", canSendTraffic=" + CanSendTraffic + ", locked=" + Locked + ", url=" + Url + "}";
        }
    }

}