﻿using Microsoft.EntityFrameworkCore;
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-7TA65AJ; database=LunaReportDB;Integrated Security=True;TrustServerCertificate=true;");
            }
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public AppDbContext()
        {
        }
        public DbSet<Report> Reports { get; set; }

    }
}
