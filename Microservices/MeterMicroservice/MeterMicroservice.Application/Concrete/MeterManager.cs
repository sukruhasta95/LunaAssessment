using Core.Utilities.Results;
using MeterMicroservice.Application.Abstract;
using MeterMicroservice.Application.Constants;
using MeterMicroservice.Entity;
using MeterMicroservice.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMicroservice.Application.Concrete
{
    public class MeterManager : IMeterService
    {
        private readonly IMeterDal _meterDal;
        public MeterManager(IMeterDal meterDal)
        {
            _meterDal = meterDal;
        }
        public IResult Add(Meter meter)
        {
            _meterDal.Add(meter);
            return new SuccessResult(MeterMessages.MeterAdded);
        }

        public void Delete(string id)
        {
            var existMeter = _meterDal.Get(x => x.Id == id);
            if (existMeter != null)
            {
                existMeter.IsDeleted = true;
                _meterDal.Update(existMeter);
            }
        }

        public IDataResult<List<Meter>> GetAll()
        {
            var meterList = _meterDal.GetList(x => !x.IsDeleted).ToList();
            return new SuccessDataResult<List<Meter>>(meterList);
        }

        public Meter GetById(string id) => _meterDal.Get(x => x.Id == id);

        public void Update(Meter meter)
        {
            _meterDal.Update(meter);
        }
    }
}
