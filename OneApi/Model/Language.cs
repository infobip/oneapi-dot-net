using System;
using OneApi.Model;
using Newtonsoft.Json;
using OneApi.Converter;
using System.ComponentModel;

namespace OneApi
{
    /// <summary>
    /// Use StringEnum.GetStringValue(LanguageCode.[VALUE]) to get the string value of the Enum
    /// </summary>
    public enum LanguageCode
    {
        [StringValue("")]
        Default,
        [StringValue("TR")]
        Turkish,
        [StringValue("PT")]
        Portuguese,
        [StringValue("ES")]
        Spanish
    }

    /// <summary>
    /// Represents language code for use with National Language Identifier (NLI) when sending messages in specific languages.
    /// </summary>
    [JsonConverter(typeof(LanguageCodeConverter))]
    public class Language
    {
        private LanguageCode lang = LanguageCode.Default;
        private bool useLockingShift = false;
        private bool useSingleShift = false;

        public LanguageCode Value 
        {
            get
            {
                return lang;
            }
            set
            {
                this.lang = value;
            }
        }

        /// <summary>
        /// (optional) see <see cref="OneApi.Model.SMSRequest.LanguageCode"/>.
        /// </summary>
        [DisplayName("useLockingShift")]
        [JsonProperty("useLockingShift")]
        public bool UseLockingShift
        {
            set
            {
                this.useLockingShift = value;
            }
            get
            {
                return useLockingShift;
            }
        }

        /// <summary>
        /// (optional) see <see cref="OneApi.Model.SMSRequest.LanguageCode"/>.
        /// </summary>
        [DisplayName("useSingleShift")]
        [JsonProperty("useSingleShift")]
        public bool UseSingleShift
        {
            set
            { 
                this.useSingleShift = value;
            }
            get
            {
                return useSingleShift;
            }
        }

        public Language(LanguageCode language)
        {
            this.lang = language;
        }

        public Language(LanguageCode language, bool useLockingShift, bool useSingleShift)
        {
            this.lang = language;
            this.useSingleShift = useSingleShift;
            this.useLockingShift = useLockingShift;
        }

        public string ToString()
        {
            return StringEnum.GetStringValue(this.lang);
        }
    }
}

