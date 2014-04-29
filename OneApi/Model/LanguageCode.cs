using System;
using OneApi.Model;
using Newtonsoft.Json;
using OneApi.Converter;

namespace OneApi
{
    /// <summary>
    /// Use StringEnum.GetStringValue(Language.[VALUE]) to get the string value of the Enum
    /// </summary>
    public enum Language
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
    public class LanguageCode
    {
        private Language lang = Language.Default;

        public Language Value { get; set; }

        public LanguageCode(Language language)
        {
            this.lang = language;
        }

        public string ToString()
        {
            return StringEnum.GetStringValue(this.lang);
        }
    }
}

