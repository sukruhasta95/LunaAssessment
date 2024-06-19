using Microsoft.EntityFrameworkCore;
using ReportMicroservice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMicroservice.Infrastructure.Concrete.EntityFramework.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-7TA65AJ; database=LunaReportDB;Integrated Security=True;TrustServerCertificate=true;");
        }
        public DbSet<Report> LunaReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>().HasData(
                new Report()
                {
                    MeterSerialNo = "aaAa11aa",
                    RequestedDate = DateTime.Now,
                    Status = EReportStatus.Completed,
                });
        }
    }
}
