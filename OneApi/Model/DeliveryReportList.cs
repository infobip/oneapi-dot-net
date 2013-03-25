using System;
using Newtonsoft.Json;

namespace OneApi.Model
{
    public class DeliveryReportList
    {
        [JsonProperty(PropertyName = "deliveryReportList")]
        public DeliveryReport[] DeliveryReports;

        public override string ToString()
        {
            return "DeliveryReportList {deliveryReports="
                + string.Join(", ", (Object[])DeliveryReports) + "}";
        }
    }
}
