using Core.Infrastructure.Concrete;
using ReportMicroservice.Entity;
using ReportMicroservice.Infrastructure.Abstract;
using ReportMicroservice.Infrastructure.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMicroservice.Infrastructure.Concrete.EntityFramework
{
    public class EfReportDal : EfEntityReporstoryBase<Report, AppDbContext>, IReportDal
    {
    }
}
