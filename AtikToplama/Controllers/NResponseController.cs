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
    public class NResponseController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<WeatherForecast> _logger;
        public NResponseController(ILogger<WeatherForecast> logger, IUnitOfWork unitOfWork)
        {

            this.unitOfWork = unitOfWork;
            _logger = logger;


        }

        public async Task<IActionResult> NkumeResponse(int id, int n)
        {
            var _vehicle = unitOfWork.Vehicle.GetVehicleWithCons(id);
            
            return Ok();
        }
    }
}
