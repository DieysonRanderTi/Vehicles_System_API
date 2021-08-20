using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Entities
{
    [DataContract]
    public class SalesAd
    {
        [Key]
        [DataMember(Name ="id")]
        public int Id { get; set; }

        [DataMember(Name ="makeCarId")]
        public int MakeCarId { get; set; }
        public MakeCar MakeCar { get; set; }

        [DataMember(Name = "carModelId")]
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }

        [DataMember(Name = "yearFabrication")]
        public DateTime YearFabrication { get; set; }

        [DataMember(Name = "saleDate")]
        public DateTime SaleDate { get; set; }

        [DataMember(Name = "buyValue")]
        public double BuyValue { get; set; }

        [DataMember(Name = "saleValue")]
        public double SaleValue { get; set; }

        [DataMember(Name = "color")]
        public string Color { get; set; }

        [DataMember(Name = "fuelType")]
        public string FuelType { get; set; }
    }
}
