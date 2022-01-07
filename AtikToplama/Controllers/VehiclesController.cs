using DataAccess.Uow;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtikToplama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<WeatherForecast> _logger;
        public VehiclesController(ILogger<WeatherForecast> logger,IUnitOfWork unitOfWork )
        {
            this.unitOfWork = unitOfWork;
            _logger = logger;
        }

        // Bütün Araçları listelemek için kullanılır.
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await unitOfWork.Vehicle.GetAll();
            return Ok(result);
        }

        // Yeni Araç eklemek için kullanılır
        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody]Vehicle vehicle )
        {
            var result = await unitOfWork.Vehicle.Add(vehicle);
            unitOfWork.Complete();
            
            return Ok(result);
        }
        // Aracı güncellemek için kullanılır.
        [HttpPut]
        public async Task<IActionResult> UpdateVehicle([FromBody] Vehicle vehicle)
        {
            var result = await unitOfWork.Vehicle.Update(vehicle);
            unitOfWork.Complete();

            return Ok(result);
        }
        // Aracı silmek için kullanılır
        [HttpDelete]
        public async Task<IActionResult> DeleteVehicle([FromQuery] long id)
        {
            var result = await unitOfWork.Vehicle.DeleteVehicleWithCons(id);
            unitOfWork.Complete();

            return Ok(result);
        }

        // Aracın gezmesi gereken bütün containerları araç bilgisi ile birlikte getirir.
        [HttpGet("VehiclesDetail")]
        public async Task<IActionResult> GetVehiclesDetail([FromQuery] long id)
        {
            var result =  unitOfWork.Vehicle.GetVehicleWithCons(id);
            return Ok(result);

        }
    }
}
