using MeterMicroservice.Application.Abstract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReportMicroservice.API.Consumers;
using ReportMicroservice.API.Events;
using ReportMicroservice.Application.Abstract;
using ReportMicroservice.Entity;
using System.Security.AccessControl;
using Wolverine;

namespace ReportMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ReportController : Controller
    {
        private IReportService _reportService;
        private IMessageBus _messageBus;
        public ReportController(IReportService reportService, IMessageBus messageBus)
        {
            _reportService = reportService;
            _messageBus = messageBus;
        }

        [HttpPost("AddReport")]
        public IActionResult Add(Report report)
        {
            var result = _reportService.Add(report);
            return Ok(result);
        }

        [HttpGet("getAllReports")]
        public IActionResult GetAll()
        {
            var result = _reportService.GetAll();
            return Ok(result);
        }

        [HttpPatch("UpdateReport")]
        public IActionResult UpdateReport([FromBody] Report report)
        {
            _reportService.Update(report);
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

        [HttpPost("TriggerReportQueue")]
        public async Task<IActionResult> TriggerReportQueue([FromBody] ReportRequestedEvent reportEvent)
        {
            await _messageBus.PublishAsync(new ReportRequestedEvent
            {
                SerialNo = reportEvent.SerialNo,
                ReportId = reportEvent.ReportId
            });
            return Ok();
        }
    }
}
