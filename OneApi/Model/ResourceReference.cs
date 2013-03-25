using System.Text;
using Newtonsoft.Json;

namespace OneApi.Model
{
	/// <summary>
	/// reference to a resource created by the OneAPI server - in the form of a generated URL
	/// </summary>
	public class ResourceReference
	{
        /// <summary>
        /// return a URL uniquely identifying a successful OneAPI server request
        /// </summary>
        [JsonProperty(PropertyName = "resourceURL")]
        public string ResourceURL { get; set; }

		/// <summary>
		/// contains a URL uniquely identifying a successful request to the OneAPI server
		/// </summary>
		public ResourceReference() : base()
		{
		}

		public ResourceReference(string resourceURL)
		{
			ResourceURL = resourceURL;
		}

		/// <summary>
		/// generate a textual representation of the ResourceReference 
		/// </summary>
        public override string ToString()
		{
			StringBuilder buffer = new StringBuilder();
			buffer.Append("resourceURL = ");
			buffer.Append(ResourceURL);
			return buffer.ToString();
		}
	}
}