using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class SalesAd
    {
        [Key]
        public int Id { get; set; }
        public int MakeCarId { get; set; }
        public MakeCar MakeCar { get; set; }
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
        public DateTime YearFabrication { get; set; }
        public DateTime SaleDate { get; set; }
        public double BuyValue { get; set; }
        public double SaleValue { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
    }
}
