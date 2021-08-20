using Domain.Data;
using Domain.Entities;
using Domain.Response;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Services.Servives
{
    public class CarMakeAndModelService: ICarMakeAndModelService
    {
        VehiclesContext context = new VehiclesContext();

        //Início dos metodos Relacionados a Marca do veículo
        public ResultResponse<MakeCar> InsertMake(MakeCar makeCar)
        {
            try
            {
                if (makeCar != null)
                {
                    context.MakeCars.Add(makeCar);
                    context.SaveChanges();

                    return new ResultResponse<MakeCar> { Data = makeCar };
                }
                else
                {
                    return Error<MakeCar>(HttpStatusCode.InternalServerError, "Não foi possivel cadastrar esta marca.", "");
                }
            }
            catch (Exception ex)
            {
                return Error<MakeCar>(HttpStatusCode.InternalServerError, "Não foi possivel cadastrar esta marca.", ex.Message);
            }
            
        }

        public ResultResponse<MakeCar> UpdateMake(int id, MakeCar makeCar)
        {
            try
            {
                var result = context.MakeCars.Where(x => x.Id == id).FirstOrDefault();

                if (result != null)
                {
                    result.Id = id;
                    result.Description = makeCar.Description;
                    context.SaveChanges();

                    return new ResultResponse<MakeCar> { Data = makeCar };
                }
                else
                {
                    return Error<MakeCar>(HttpStatusCode.InternalServerError, "Não foi possivel Editar esta marca.", "");
                }
            }
            catch (Exception ex)
            {
                return Error<MakeCar>(HttpStatusCode.InternalServerError, "Não foi possivel Editar esta marca.", ex.Message);
            }

        }

        public ResultResponse<MakeCar> DeleteMake(int id)
        {
            try
            {
                var result = context.MakeCars.Where(x => x.Id == id).FirstOrDefault();

                if (result != null)
                {
                    context.Remove(result);
                    context.SaveChanges();

                    return new ResultResponse<MakeCar> { Data = result };
                }
                else
                {
                    return Error<MakeCar>(HttpStatusCode.InternalServerError, "Não foi possivel deletar esta marca.", "");
                }
            }
            catch (Exception ex)
            {
                return Error<MakeCar>(HttpStatusCode.InternalServerError, "Não foi possivel deletar esta marca.", ex.Message);
            }

        }
        //Fim dos metodos Relacionados a Marca do veículo

        //Início dos metodos Relacionados ao Modelo do veículo
        public ResultResponse<CarModel> InsertCarModel(CarModel carModel)
        {
            try
            {
                if (carModel != null)
                {
                    context.CarModels.Add(carModel);
                    context.SaveChanges();

                    return new ResultResponse<CarModel> { Data = carModel };
                }
                else
                {
                    return Error<CarModel>(HttpStatusCode.InternalServerError, "Não foi possivel cadastrar este modelo.", "");
                }
            }
            catch (Exception ex)
            {
                return Error<CarModel>(HttpStatusCode.InternalServerError, "Não foi possivel cadastrar este modelo.", ex.Message);
            }

        }

        public ResultResponse<CarModel> UpdateCarModel(int id, CarModel carModel)
        {
            try
            {
                var result = context.CarModels.Where(x => x.Id == id).FirstOrDefault();

                if (result != null)
                {
                    result.Id = id;
                    result.Description = carModel.Description;
                    context.SaveChanges();

                    return new ResultResponse<CarModel> { Data = carModel };
                }
                else
                {
                    return Error<CarModel>(HttpStatusCode.InternalServerError, "Não foi possivel Editar este modelo.", "");
                }
            }
            catch (Exception ex)
            {
                return Error<CarModel>(HttpStatusCode.InternalServerError, "Não foi possivel Editar este modelo.", ex.Message);
            }

        }

        public ResultResponse<CarModel> DeleteCarModel(int id)
        {
            try
            {
                var result = context.CarModels.Where(x => x.Id == id).FirstOrDefault();

                if (result != null)
                {
                    context.Remove(result);
                    context.SaveChanges();

                    return new ResultResponse<CarModel> { Data = result };
                }
                else
                {
                    return Error<CarModel>(HttpStatusCode.InternalServerError, "Não foi possivel deletar este modelo.", "");
                }
            }
            catch (Exception ex)
            {
                return Error<CarModel>(HttpStatusCode.InternalServerError, "Não foi possivel deletar este modelo.", ex.Message);
            }

        }
        //Fim dos metodos Relacionados ao Modelo do veículo

        private ResultResponse<T> Error<T>(HttpStatusCode status, string message, string details) where T : new()
        {
            return new ResultResponse<T>
            {
                Error = true,
                Errors = new List<Errors>
                {
                    new Errors
                    {
                        Id = Guid.NewGuid(), Message = message, Details = details
                    }
                },
                StatusCode = status
            };
        }
    }
}
