using Core.Infrastructure.Concrete;
using MeterMicroservice.Entity;
using MeterMicroservice.Infrastructure.Abstract;
using MeterMicroservice.Infrastructure.Concrete.EntityFramework.Context;

namespace MeterMicroservice.Infrastructure.Concrete.EntityFramework
{
    public class EfMeterDal:EfEntityReporstoryBase<Meter,AppDbContext>,IMeterDal
    {
    }
}
