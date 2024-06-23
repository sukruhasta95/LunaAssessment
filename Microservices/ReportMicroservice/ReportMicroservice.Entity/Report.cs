using Core.Entity.Abstract;
using Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMicroservice.Entity
{
    public class Report:BaseEntity,IEntity
    {
        public DateTime RequestedDate { get; set; }
        public EReportStatus Status { get; set; }
        public string MeterSerialNo { get; set; }
        public string? ReportPath { get; set; }
    }
}
