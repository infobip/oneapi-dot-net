using Newtonsoft.Json;

namespace OneApi.Model
{
    public class Country
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "prefix")]
        public string Prefix { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        public Country()
        {
        }

        public static bool operator ==(Country c1, Country c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Country c1, Country c2)
        {
            return !(c1.Equals(c2));
        }

        public override bool Equals(object obj)
        {
            Country c = obj as Country;
            if (c == null)
                return false;

            if (Code != null ? Code != c.Code : c.Code != null)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return Code != null ? Code.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return "Country{" +
                    "id=" + Id +
                    ", code='" + Code + '\'' +
                    ", prefix='" + Prefix + '\'' +
                    ", name='" + Name + '\'' +
                    ", locale='" + Locale + '\'' +
                    '}';
        }
    }
}
