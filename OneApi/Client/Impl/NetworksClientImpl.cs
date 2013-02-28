using System.Text;
using OneApi.Config;
using OneApi.Model;
using RestSharp;

namespace OneApi.Client.Impl
{
    public class NetworksClientImpl : OneAPIBaseClientImpl, NetworksClient
    {
        private const string NETWORKS_URL_BASE = "/networks";

        public NetworksClientImpl(Configuration configuration)
            : base(configuration)
        {
        }

        /// <summary>
        /// Gets an array of Networks
        /// </summary>
        /// <returns>Network[]</returns>
        public Network[] GetNetworks()
        {
            RequestData requestData = new RequestData(NETWORKS_URL_BASE, Method.GET, "networks");
            return ExecuteMethod<Network[]>(requestData);
        }

        /// <summary>
        /// Gets the given GSM number's informations
        /// </summary>
        /// <param name="gsmNumber">The GSM number</param>
        /// <returns>NumberInfo</returns>
        public NumberInfo ResolveMSISDN(string gsmNumber)
        {
            StringBuilder sb = new StringBuilder(NETWORKS_URL_BASE);
            sb.Append("/resolve").Append("/").Append(gsmNumber);

            RequestData requestData = new RequestData(sb.ToString(), Method.POST);
            requestData.Request.MediaType = "application/x-www-form-urlencoded";
            return ExecuteMethod<NumberInfo>(requestData);
        }
    }
}
