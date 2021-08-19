using Domain.Data;
using Domain.Entities;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using static Domain.Response.ResultResponse<T>;

namespace Services.Servives
{
    public class VehiclesServices
    {
        VehiclesContext context = new VehiclesContext();

        public ResultResponse<SalesAd> InsertSaleAd(SalesAd ad)
        {
            SalesAd response = new SalesAd();
            try
            {
                if(ad != null)
                {
                    //SalesAd response = new SalesAd
                    //{
                    //    Id = ad.Id,
                    //    CarModelId = ad.CarModelId,
                    //    Color = ad.Color,
                    //    BuyValue = ad.BuyValue,
                    //    FuelType = ad.FuelType,
                    //    MakeCarId = ad.MakeCarId,
                    //    SaleDate = ad.SaleDate,
                    //    SaleValue = ad.SaleValue,
                    //    YearFabrication = ad.YearFabrication
                    //};
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
