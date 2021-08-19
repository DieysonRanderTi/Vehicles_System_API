using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Data
{
    public class VehiclesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SalesAd> SaleAds { get; set; }
        public DbSet<MakeCar> MakeCars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("datasource=localhost;database=VehiclesDb;port=3306;username=root;password=drstcpf041190;SslMode=none;AllowPublicKeyRetrieval = True");
        }   

    }
}
