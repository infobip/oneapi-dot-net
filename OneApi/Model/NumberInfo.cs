using System;

namespace OneApi.Model
{
    public class NumberInfo
    {
        public Network Network { get; set; }
        public Country Country { get; set; }
        public string MSISDN { get; set; }
        public string NetworkPrefix { get; set; }

       public override string ToString()
        {
            return "MSISDN: " + MSISDN.ToString() + ", Network prefix: " +NetworkPrefix.ToString()+ ", " + Network.ToString() + "," + Country.ToString();
        }
    }
}
