using Core.Utilities.Results;
using MeterMicroservice.Application.Concrete;
using MeterMicroservice.Application.Constants;
using MeterMicroservice.Entity;
using MeterMicroservice.Infrastructure.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;
using Assert = Xunit.Assert;

namespace MeterMicroservice.Tests
{
    public class MeterManagerTests
    {
        private readonly Mock<IMeterDal> _mockMeterDal;
        private readonly MeterManager _meterManager;

        public MeterManagerTests()
        {
            _mockMeterDal = new Mock<IMeterDal>();
            _meterManager = new MeterManager(_mockMeterDal.Object);
        }

        [Fact]
        public void AddTest()
        {
            var meter = new Meter();

            var result = _meterManager.Add(meter);

            _mockMeterDal.Verify(m => m.Add(It.IsAny<Meter>()), Times.Once);
            Assert.True(result.Success);
            Assert.Equal(MeterMessages.MeterAdded, result.Message);
        }

        [Fact]
        public void DeleteTest()
        {
            var meter = new Meter { Id = "1", IsDeleted = false };
            _mockMeterDal.Setup(m => m.Get(It.IsAny<Expression<Func<Meter, bool>>>())).Returns((Expression<Func<Meter, bool>> predicate) => meter);

            _meterManager.Delete("1");

            _mockMeterDal.Verify(m => m.Get(It.IsAny<Expression<Func<Meter, bool>>>()), Times.Once);
            _mockMeterDal.Verify(m => m.Update(It.IsAny<Meter>()), Times.Once);
            Assert.True(meter.IsDeleted);
        }

        [Fact]
        public void GetAllTest()
        {
            var meters = new List<Meter> { new(), new() };
            _mockMeterDal.Setup(m => m.GetList(It.IsAny<Expression<Func<Meter, bool>>>())).Returns((Expression<Func<Meter, bool>> predicate) => meters.Where(predicate.Compile()).ToList());

            var result = _meterManager.GetAll();

            _mockMeterDal.Verify(m => m.GetList(It.IsAny<Expression<Func<Meter, bool>>>()), Times.Once);
            Assert.True(result.Success);
            Assert.Equal(2, result.Data.Count);
        }

        [Fact]
        public void GetByIdTest()
        {
            var meter = new Meter { Id = "1" };
            _mockMeterDal.Setup(m => m.Get(It.IsAny<Expression<Func<Meter, bool>>>()))
             .Returns((Expression<Func<Meter, bool>> predicate) => meter);

            var result = _meterManager.GetById("1");

            _mockMeterDal.Verify(m => m.Get(It.IsAny<Expression<Func<Meter, bool>>>()), Times.Once);
            Assert.Equal(meter, result);
        }

        [Fact]
        public void GetBySerialNoTest()
        {
            var meters = new List<Meter>
            {
                new Meter { MeterSerialNo = "123", MeasurementTime = DateTime.Now.AddHours(-1) },
                new Meter { MeterSerialNo = "123", MeasurementTime = DateTime.Now }
            };
            _mockMeterDal.Setup(m => m.GetList(It.IsAny<Expression<Func<Meter, bool>>>()))
              .Returns((Expression<Func<Meter, bool>> predicate) => meters.Where(predicate.Compile()).ToList());

            var result = _meterManager.GetBySerialNo("123");

            _mockMeterDal.Verify(m => m.GetList(It.IsAny<Expression<Func<Meter, bool>>>()), Times.Once);
            Assert.Equal(2, result.Count);
            Assert.Equal(meters.OrderByDescending(x => x.MeasurementTime).ToList(), result);
        }

        [Fact]
        public void UpdateTest()
        {
            var meter = new Meter { Id = "1" };

            _meterManager.Update(meter);

            _mockMeterDal.Verify(m => m.Update(It.IsAny<Meter>()), Times.Once);
        }
    }
}
