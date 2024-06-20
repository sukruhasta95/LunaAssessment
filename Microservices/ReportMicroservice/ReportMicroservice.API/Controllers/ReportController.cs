using MeterMicroservice.Application.Abstract;
using Microsoft.AspNetCore.Mvc;
using ReportMicroservice.Application.Abstract;
using ReportMicroservice.Entity;

namespace ReportMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("AddReport")]
        public IActionResult Add(Report meter)
        {
            var result = _reportService.Add(meter);
            return Ok(result);
        }

        [HttpGet("getAllReports")]
        public IActionResult GetAll()
        {
            var result = _reportService.GetAll();
            return Ok(result);
        }

        [HttpPatch("UpdateReport")]
        public IActionResult UpdateMeter(Report meter)
        {
            _reportService.Update(meter);
            return Ok();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _reportService.GetById(id);
            return Ok(result);
        }

        [HttpPatch("DeleteReport")]
        public IActionResult Delete(string id)
        {
            _reportService.Delete(id);
            return Ok();
        }
    }
}
