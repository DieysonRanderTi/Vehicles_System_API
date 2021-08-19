using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Data
{
    public static class InitialData
    {
        public static void Initialize(VehiclesContext context)
        {
            context.Database.EnsureCreated();

            if (context.CarModels.Any() && context.MakeCars.Any() &&
                context.SaleAds.Any() && context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                 new User{Id = 1,UserName="admin", Password="123456", Admin= true}
            };

            var makeCars = new MakeCar[]
            {
                new MakeCar{Id = 1, Description="Way 1.0 Flex"}
            };

            var carModel = new CarModel[]
            {
                new CarModel{Id = 1, Description="Uno"}
            };

            var saleAd = new SalesAd[]
            {
                new SalesAd{Id= 1, CarModelId=1, MakeCarId=1, BuyValue=22.399, SaleValue=26.899,
                            Color="Branco", FuelType="Flex", SaleDate=DateTime.Now, YearFabrication=DateTime.Now}
            };

            context.Add(users);
            context.Add(makeCars);
            context.Add(carModel);
            context.Add(saleAd);

            context.SaveChanges();
        }
    }
}
