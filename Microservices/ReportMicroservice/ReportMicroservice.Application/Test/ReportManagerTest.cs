using Moq;
using Xunit;
using ReportMicroservice.Application.Concrete;
using ReportMicroservice.Application.Constants;
using ReportMicroservice.Entity;
using ReportMicroservice.Infrastructure.Abstract;
using Assert = Xunit.Assert;
using System.Linq.Expressions;

namespace ReportMicroservice.UnitTests
{
    public class ReportManagerTests
    {
        private readonly Mock<IReportDal> _mockReportDal;
        private readonly ReportManager _reportManager;

        public ReportManagerTests()
        {
            _mockReportDal = new Mock<IReportDal>();
            _reportManager = new ReportManager(_mockReportDal.Object);
        }

        [Fact]
        public void AddTest()
        {
            var report = new Report { Id = "1" };

            _mockReportDal.Setup(m => m.Add(report));

            var result = _reportManager.Add(report);

            Assert.True(result.Success);
            Assert.Equal(ReportMessages.ReportAdded, result.Message);
            _mockReportDal.Verify(m => m.Add(report), Times.Once);
        }

        [Fact]
        public void DeleteTest()
        {
            var report = new Report { Id = "1", IsDeleted = false };
            _mockReportDal.Setup(m => m.Get(It.IsAny<Expression<Func<Report, bool>>>())).Returns((Expression<Func<Report, bool>> predicate) => report);

            _reportManager.Delete("1");

            _mockReportDal.Verify(m => m.Get(It.IsAny<Expression<Func<Report, bool>>>()), Times.Once);
            _mockReportDal.Verify(m => m.Update(It.IsAny<Report>()), Times.Once);
            Assert.True(report.IsDeleted);
        }

        [Fact]
        public void GetAllTest()
        {
            var reports = new List<Report> { new(), new() };
            _mockReportDal.Setup(m => m.GetList(It.IsAny<Expression<Func<Report, bool>>>())).Returns((Expression<Func<Report, bool>> predicate) => reports.Where(predicate.Compile()).ToList());

            var result = _reportManager.GetAll();

            _mockReportDal.Verify(m => m.GetList(It.IsAny<Expression<Func<Report, bool>>>()), Times.Once);
            Assert.True(result.Success);
            Assert.Equal(2, result.Data.Count);
        }

        [Fact]
        public void GetByIdTest()
        {
            var report = new Report { Id = "1" };
            _mockReportDal.Setup(m => m.Get(It.IsAny<Expression<Func<Report, bool>>>()))
             .Returns((Expression<Func<Report, bool>> predicate) => report);

            var result = _reportManager.GetById("1");

            _mockReportDal.Verify(m => m.Get(It.IsAny<Expression<Func<Report, bool>>>()), Times.Once);
            Assert.Equal(report, result); ;
        }

        [Fact]
        public void UpdateTest()
        {
            var report = new Report { Id = "1" };
            _reportManager.Update(report);
            _mockReportDal.Verify(m => m.Update(It.IsAny<Report>()), Times.Once);
        }
    }
}
