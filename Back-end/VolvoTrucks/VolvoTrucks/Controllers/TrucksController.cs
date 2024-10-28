using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using VolvoTrucks.Api.Services;

namespace VolvoTrucks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrucksController : ControllerBase
    {
        private readonly ILogger<TrucksController> _logger;
        private readonly ITruckService _truckService;

        public TrucksController(ILogger<TrucksController> logger, ITruckService truckService)
        {
            _logger = logger;
            _truckService = truckService;
        }

        
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Truck truck)
        {
            try
            {
                _logger.LogInformation($"{Request.Path} : {JsonSerializer.Serialize(truck)}");
                return Ok(await _truckService.Create(truck));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                _logger.LogInformation($"{Request.Path} : {Id}");
                return Ok(await _truckService.Get(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation($"{Request.Path}");
                return Ok(await _truckService.GetAllTrucks());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody]Truck truck)
        {
            try
            {
                _logger.LogInformation($"{Request.Path} : {JsonSerializer.Serialize(truck)}");
                return Ok(await _truckService.Update(truck));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                _logger.LogInformation($"{Request.Path} : {Id}");
                return Ok(await _truckService.Delete(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
