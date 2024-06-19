using Core.Infrastructure.Abstract;
using ReportMicroservice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMicroservice.Infrastructure.Abstract
{
    public interface IReportDal:IEntityRepostory<Report>
    {
    }
}
