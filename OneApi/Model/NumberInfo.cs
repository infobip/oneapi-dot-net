using System;

namespace OneApi.Model
{
    public class NumberInfo
    {
        public Network network { get; set; }
        public Country country { get; set; }
        public string msisdn { get; set; }
        public string networkPrefix { get; set; }
    }
}
