using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace OneApi.Model
{
    public class DeliveryReportList
    {
        [JsonProperty(PropertyName = "deliveryReportList")]
        public DeliveryReport[] DeliveryReports;

        public override string ToString()
        {
            return "DeliveryReportList {deliveryReports=" + string.Join(", ",
                    DeliveryReports.Select<DeliveryReport, string>(deliveryR => deliveryR != null ? deliveryR.ToString() : "{}")
                    .ToArray()) + "}";
        }
    }
}
