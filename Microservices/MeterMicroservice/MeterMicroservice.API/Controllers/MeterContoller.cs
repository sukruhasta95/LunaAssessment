using MeterMicroservice.Application.Abstract;
using MeterMicroservice.Entity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MeterMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class MeterContoller : Controller
    {
        private IMeterService _meterService;

        public MeterContoller(IMeterService meterService)
        {
            _meterService = meterService;
        }

        [HttpPost("AddMeter")]
        public IActionResult Add(Meter meter)
        {
            var result = _meterService.Add(meter);
            return Ok(result);
        }

        [HttpGet("getAllMeter")]
        public IActionResult GetAll()
        {
            var result = _meterService.GetAll();
            return Ok(result);
        }

        [HttpPatch("UpdateMeter")]
        public IActionResult UpdateMeter(Meter meter)
        {
            _meterService.Update(meter);
            return Ok();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _meterService.GetById(id);
            return Ok(result);
        }

        [HttpPatch("DeleteMeter")]
        public IActionResult Delete(string id)
        {
            _meterService.Delete(id);
            return Ok();
        }
    }
}
