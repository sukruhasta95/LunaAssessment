using Core.Application.Abstract;
using Core.Utilities.Results;
using ReportMicroservice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMicroservice.Application.Abstract
{
    public interface IReportService:IApplicationService<Report>
    {
    }
}
