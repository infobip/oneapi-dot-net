using OneApi.Model;

namespace OneApi.Client
{
    public interface NetworksClient
    {
        /// <summary>
        /// Returns a list of networks.
        /// </summary>
        /// <returns>Network[]</returns>
        Network[] GetNetworks();

        NumberInfo ResolveMSISDN(string gsmNumber);
    }
}
