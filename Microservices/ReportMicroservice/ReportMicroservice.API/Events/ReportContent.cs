using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMicroservice.API.Events
{
    public class ReportContent
    {
        public DateTime MeasurementTime { get; set; }
        public int LastIndex { get; set; }
        public double VoltageValue { get; set; }
        public double CurrentValue { get; set; }

        public string MeterSerialNo { get; set; }
    }
}
