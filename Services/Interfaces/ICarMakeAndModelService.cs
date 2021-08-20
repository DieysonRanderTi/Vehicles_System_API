using Domain.Entities;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICarMakeAndModelService
    {
        public ResultResponse<MakeCar> InsertMake(MakeCar makeCar);
        public ResultResponse<MakeCar> UpdateMake(int id, MakeCar makeCar);
        public ResultResponse<MakeCar> DeleteMake(int id);


        public ResultResponse<CarModel> InsertCarModel(CarModel carModel);
        public ResultResponse<CarModel> UpdateCarModel(int id, CarModel carModel);
        public ResultResponse<CarModel> DeleteCarModel(int id);

    }
}
