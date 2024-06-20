using Core.Utilities.Results;
using ReportMicroservice.Application.Abstract;
using ReportMicroservice.Application.Constants;
using ReportMicroservice.Entity;
using ReportMicroservice.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMicroservice.Application.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }
        public IResult Add(Report report)
        {
            _reportDal.Add(report);
            return new SuccessResult(ReportMessages.ReportAdded);
        }

        public void Delete(string id)
        {
            var existReport = _reportDal.Get(x => x.Id == id);
            if (existReport != null)
            {
                existReport.IsDeleted = true;
                _reportDal.Update(existReport);
            }
        }

        public IDataResult<List<Report>> GetAll()
        {
            var reportList = _reportDal.GetList(x => !x.IsDeleted).ToList();
            return new SuccessDataResult<List<Report>>(reportList);
        }

        public Report GetById(string id) => _reportDal.Get(x => x.Id == id);


        public void Update(Report report)
        {
            _reportDal.Update(report);
        }
    }
}
