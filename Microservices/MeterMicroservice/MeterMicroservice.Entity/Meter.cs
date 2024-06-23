using Core.Entity.Abstract;
using Core.Entity.Concrete;
using System.ComponentModel.DataAnnotations;

namespace MeterMicroservice.Entity
{
    public class Meter:BaseEntity,IEntity
    {
        public string MeterSerialNo { get; set; }
        public DateTime MeasurementTime { get; set;}
        public int LastIndex { get; set; }
        public double VoltageValue { get; set; }
        public double CurrentValue { get; set; }
    }
}
