using Core.Application.Abstract;
using Core.Utilities.Results;
using MeterMicroservice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMicroservice.Application.Abstract
{
    public interface IMeterService:IApplicationService<Meter>
    {
        List<Meter> GetBySerialNo(string serialNo);
    }
}
