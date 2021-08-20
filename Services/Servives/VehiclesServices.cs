using Domain.Data;
using Domain.Entities;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Services.Servives
{
    public class VehiclesServices: IVehiclesService
    {
        VehiclesContext context = new VehiclesContext();

        public IEnumerable<SalesAd> GetAll()
        {
          
               var saleAds = context.SaleAds.ToList();

               return saleAds;
           
        }

        public ResultResponse<SalesAd> GetOne(int id)
        {
            try
            {
                var result = context.SaleAds.Where(x => x.Id == id).FirstOrDefault();

                if(result == null)
                {
                    return Error<SalesAd>(HttpStatusCode.InternalServerError, "Anúncio não encontrado", "");
                }
                else
                {
                    return new ResultResponse<SalesAd> { Data = result };
                }
                
            }
            catch (Exception ex)
            {
                return Error<SalesAd>(HttpStatusCode.InternalServerError, "Erro ao buscar o resgistro", ex.Message);             
            }
            

        }

        public ResultResponse<SalesAd> InsertSaleAd(SalesAd ad)
        {
            SalesAd response = new SalesAd();
            try
            {
                if(ad != null)
                {
                    response = ad;
                    context.SaleAds.Add(response);
                    context.SaveChanges();
                }

                return new ResultResponse<SalesAd> { Data = response };
            }
            catch (Exception ex)
            {
                return Error<SalesAd>(HttpStatusCode.InternalServerError, "Erro ao cadastrar o anuncio", ex.Message);
            }
        }

        public ResultResponse<SalesAd> UpdateSaleAd(int id, SalesAd saleAd)
        {
            try
            {
                var newSaleAd = context.SaleAds.Where(x => x.Id == id).FirstOrDefault();

                if (newSaleAd != null)
                {
                    newSaleAd.Id = id;
                    newSaleAd.MakeCarId = saleAd.MakeCarId;
                    newSaleAd.SaleDate = saleAd.SaleDate;
                    newSaleAd.SaleValue = saleAd.SaleValue;
                    newSaleAd.YearFabrication = saleAd.YearFabrication;
                    newSaleAd.BuyValue = saleAd.BuyValue;
                    newSaleAd.CarModelId = saleAd.CarModelId;
                    newSaleAd.Color = saleAd.Color;
                    newSaleAd.FuelType = saleAd.FuelType;

                    context.SaveChanges();

                    return new ResultResponse<SalesAd> { Data = newSaleAd };
                }
                else {
                    return Error<SalesAd>(HttpStatusCode.InternalServerError, "Erro ao atualizar o produto", "");
                }

               
            }
            catch (Exception ex)
            {

                return Error<SalesAd>(HttpStatusCode.InternalServerError, "Erro ao atualizar o produto", ex.Message);
            }
        }

        public ResultResponse<SalesAd> DeleteSaleAd(int id)
        {
            try
            {
                var saleAd = context.SaleAds.Where(x => x.Id == id).FirstOrDefault();

                if (saleAd != null)
                {
                    context.SaleAds.Remove(saleAd);
                    context.SaveChanges();
                }

                return new ResultResponse<SalesAd> { Data = saleAd };
            }
            catch (Exception ex)
            {
                return Error<SalesAd>(HttpStatusCode.InternalServerError, "Não foi possivel excluir o resgistro", ex.Message);
            }
           
        }

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
