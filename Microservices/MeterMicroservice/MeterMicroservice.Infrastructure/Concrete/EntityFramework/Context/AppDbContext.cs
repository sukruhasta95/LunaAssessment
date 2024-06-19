using MeterMicroservice.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMicroservice.Infrastructure.Concrete.EntityFramework.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-7TA65AJ; database=LunaMeterDB;Integrated Security=True;TrustServerCertificate=true;");
        }

        public DbSet<Meter> Meters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meter>().HasData(
                new Meter()
                {
                   MeterSerialNo = "aaAa11aa",
                   MeasurementTime = DateTime.Now,
                   LastIndex = 2,
                   VoltageValue = 10,
                   CurrentValue = 10,
                }) ;
        }
    }
}
