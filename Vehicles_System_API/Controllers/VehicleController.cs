using Domain.Entities;
using Domain.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Vehicles_System_API.Controllers
{
    [ApiController]
    [Route("services")]
    public class VehicleController : Controller
    {
        private readonly IVehiclesService _vehiclesService;

        public VehicleController
        (
            IVehiclesService vehiclesService
        )
        {
            _vehiclesService = vehiclesService;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_vehiclesService.GetAll());
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetOne(int id)
        {
            ResultResponse<SalesAd> resultService = _vehiclesService.GetOne(id);

            int statusCode = !resultService.Error ? (int)HttpStatusCode.OK : (int)resultService.StatusCode;

            return StatusCode(statusCode, new { result = resultService });
        }

        [HttpPost]
        [Route("insertSaleAd")]
        public IActionResult InsertSaleAd(SalesAd saleAd)
        {
            ResultResponse<SalesAd> resultService = _vehiclesService.InsertSaleAd(saleAd);

            int statusCode = !resultService.Error ? (int)HttpStatusCode.OK : (int)resultService.StatusCode;

            return StatusCode(statusCode, new { result = resultService });
        }

        [HttpPut]
        [Route("edit/{id}")]
        public IActionResult UpdadeSaleAd(int id, SalesAd saleAd)
        {
            ResultResponse<SalesAd> resultService = _vehiclesService.UpdateSaleAd(id, saleAd);

            int statusCode = !resultService.Error ? (int)HttpStatusCode.OK : (int)resultService.StatusCode;

            return StatusCode(statusCode, new { result = resultService });
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteSaleAd(int id)
        {
            ResultResponse<SalesAd> resultService = _vehiclesService.DeleteSaleAd(id);

            int statusCode = !resultService.Error ? (int)HttpStatusCode.OK : (int)resultService.StatusCode;

            return StatusCode(statusCode, new { result = resultService });
        }
    }
}
