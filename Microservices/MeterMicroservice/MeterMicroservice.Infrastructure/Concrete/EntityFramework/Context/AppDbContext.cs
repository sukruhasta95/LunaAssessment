using MeterMicroservice.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-7TA65AJ; database=LunaMeterDB;Integrated Security=True;TrustServerCertificate=true;");
            }
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public AppDbContext() : base()
        {
        }

        public DbSet<Meter> Meters { get; set; }

    }
}
