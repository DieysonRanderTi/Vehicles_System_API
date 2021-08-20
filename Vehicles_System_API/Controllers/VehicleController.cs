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
        private readonly IUserService _userService;
        private readonly ICarMakeAndModelService _carMakeAndModelService;

        public VehicleController
        (
            IVehiclesService vehiclesService,
            IUserService userService,
            ICarMakeAndModelService carMakeAndModel
        )
        {
            _vehiclesService = vehiclesService;
            _userService = userService;
            _carMakeAndModelService = carMakeAndModel;
        }

        //Inicio dos controladores dos Anúncios
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
        //Fim dos controladores dos Anúncios

        //Inicio dos controladores dos Usuários
        [HttpPost]
        [Route("insertUser")]
        public IActionResult InsertUser(User user)
        {
            ResultResponse<User> resultService = _userService.InsertUser(user);

            int statusCode = !resultService.Error ? (int)HttpStatusCode.OK : (int)resultService.StatusCode;

            return StatusCode(statusCode, new { result = resultService });
        }

        [HttpPut]
        [Route("editUser/{id}")]
        public IActionResult UpdadeUser(int id, User user)
        {
            ResultResponse<User> resultService = _userService.UpdateUser(id, user);

            int statusCode = !resultService.Error ? (int)HttpStatusCode.OK : (int)resultService.StatusCode;

            return StatusCode(statusCode, new { result = resultService });
        }

        [HttpDelete]
        [Route("deleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            ResultResponse<User> resultService = _userService.DeleteUser(id);

            int statusCode = !resultService.Error ? (int)HttpStatusCode.OK : (int)resultService.StatusCode;

            return StatusCode(statusCode, new { result = resultService });
        }
        //Fim dos controladores dos Usuários

        //Inicio dos controladores da Marca do veiculo
        [HttpPost]
        [Route("insertMakeCar")]
        public IActionResult InsertMakeCar(MakeCar makeCar)
        {
            ResultResponse<MakeCar> resultService = _carMakeAndModelService.InsertMake(makeCar);

            int statusCode = !resultService.Error ? (int)HttpStatusCode.OK : (int)resultService.StatusCode;

            return StatusCode(statusCode, new { result = resultService });
        }
        [HttpPut]
        [Route("editMakeCar/{id}")]
        public IActionResult UpdadeMakeCar(int id, MakeCar makeCar)
        {
            ResultResponse<MakeCar> resultService = _carMakeAndModelService.UpdateMake(id, makeCar);

            int statusCode = !resultService.Error ? (int)HttpStatusCode.OK : (int)resultService.StatusCode;

            return StatusCode(statusCode, new { result = resultService });
        }
        [HttpDelete]
        [Route("deleteMakeCar/{id}")]
        public IActionResult DeleteMakeCar(int id)
        {
            ResultResponse<MakeCar> resultService = _carMakeAndModelService.DeleteMake(id);

            int statusCode = !resultService.Error ? (int)HttpStatusCode.OK : (int)resultService.StatusCode;

            return StatusCode(statusCode, new { result = resultService });
        }
        //Fim dos controladores da Marca do veiculo

        //Inicio dos controladores do modelo do veiculo
        [HttpPost]
        [Route("insertCarModel")]
        public IActionResult InsertCarModel(CarModel carModel)
        {
            ResultResponse<CarModel> resultService = _carMakeAndModelService.InsertCarModel(carModel);

            int statusCode = !resultService.Error ? (int)HttpStatusCode.OK : (int)resultService.StatusCode;

            return StatusCode(statusCode, new { result = resultService });
        }
        [HttpPut]
        [Route("editCarModel/{id}")]
        public IActionResult UpdadeCarModel(int id, CarModel carModel)
        {
            ResultResponse<CarModel> resultService = _carMakeAndModelService.UpdateCarModel(id, carModel);

            int statusCode = !resultService.Error ? (int)HttpStatusCode.OK : (int)resultService.StatusCode;

            return StatusCode(statusCode, new { result = resultService });
        }
        [HttpDelete]
        [Route("deleteMakeCar/{id}")]
        public IActionResult DeleteCarModel(int id)
        {
            ResultResponse<CarModel> resultService = _carMakeAndModelService.DeleteCarModel(id);

            int statusCode = !resultService.Error ? (int)HttpStatusCode.OK : (int)resultService.StatusCode;

            return StatusCode(statusCode, new { result = resultService });
        }
        //Fim dos controladores do modelo do veiculo
    }
}
