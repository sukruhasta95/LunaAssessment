using Core.Infrastructure.Abstract;
using MeterMicroservice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMicroservice.Infrastructure.Abstract
{
    public interface IMeterDal: IEntityRepostory<Meter>
    {
    }
}
