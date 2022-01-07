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
    public class ContainerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<WeatherForecast> _logger;
        public ContainerController(ILogger<WeatherForecast> logger, IUnitOfWork unitOfWork)
        {
        
            this.unitOfWork = unitOfWork;
            _logger = logger;
        
        }

        // Bütün Containerları listeler.
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await unitOfWork.Container.GetAll();
            return Ok(result);
        }

        // Yeni bir Container eklemek için kullanılır.
        [HttpPost]
        public async Task<IActionResult> AddContainer([FromBody] Container container)
        {
            var result = await unitOfWork.Container.Add(container);
            unitOfWork.Complete();
            return Ok();
        }
        //Container güncellemek için kullanılır VehicleId eğer post edilmemişse VehicleId Değişmez.
        [HttpPut]
        public  async Task<IActionResult> UpdateContainer([FromBody] Container container)
        {
            
            await unitOfWork.Container.ContainerUpdate(container);
            unitOfWork.Complete();
            return Ok();
        }

        //Container siler
        [HttpDelete]
        public async Task<IActionResult> DeleteContainer([FromQuery] int id)
        {

            await unitOfWork.Container.Delete(id);
            unitOfWork.Complete();
            return Ok();
        }

        // VehicleId'ye bağlı olan bütün containerları listeler.
        [HttpGet("GetContainers")]
        public async Task<IActionResult> GetContainers([FromQuery] int id)
        {

             var _containers=await unitOfWork.Container.GetAll();
            var result = _containers.Where(x => x.VehicleId == id);
            unitOfWork.Complete();
            return Ok(result);
        }
    }
}
