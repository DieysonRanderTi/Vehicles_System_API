using Domain.Entities;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IVehiclesService
    {
        public IEnumerable<SalesAd> GetAll();

        public ResultResponse<SalesAd> GetOne(int id);

        public ResultResponse<SalesAd> InsertSaleAd(SalesAd ad);

        public ResultResponse<SalesAd> UpdateSaleAd(int id, SalesAd ad);

        public ResultResponse<SalesAd> DeleteSaleAd(int id);
    }
}
