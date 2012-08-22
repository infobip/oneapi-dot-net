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
            StringBuilder buffer = new StringBuilder();
            if (DeliveryReports != null)
            {
                for (int i = 0; i < DeliveryReports.Length; i++)
                {
                    buffer.Append("[");
                    buffer.Append(i);
                    buffer.Append("] = {");
                    buffer.Append(DeliveryReports[i].ToString());
                    buffer.Append("} ");
                }
            }
            buffer.Append("} ");

            return buffer.ToString();

        }
    }
}
