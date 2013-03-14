using System.Collections.Generic;
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
            return ExecuteMethod<NumberInfo>(requestData);
        }

        /// <summary>
        /// Gets the given GSM numbers's informations
        /// </summary>
        /// <param name="gsmNumbers"></param>
        /// <returns></returns>
        public NumberInfo[] ResolveMSISDNs(List<string> gsmNumbers)
        {
            RequestData requestData = new RequestData(NETWORKS_URL_BASE, Method.POST, gsmNumbers);
            requestData.ContentType = RequestData.JSON_CONTENT_TYPE;
            return ExecuteMethod<NumberInfo[]>(requestData);
        }




    }
}
