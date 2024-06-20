﻿// <auto-generated />
using System;
using MeterMicroservice.Infrastructure.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeterMicroservice.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MeterMicroservice.Entity.Meter", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("CurrentValue")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LastIndex")
                        .HasColumnType("int");

                    b.Property<DateTime>("MeasurementTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MeterSerialNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("VoltageValue")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Meters");

                    b.HasData(
                        new
                        {
                            Id = "49691b96-9227-4461-83b2-b21ffbd1c76d",
                            CreatedOn = new DateTime(2024, 6, 21, 1, 54, 11, 688, DateTimeKind.Local).AddTicks(7603),
                            CurrentValue = 10.0,
                            IsDeleted = false,
                            LastIndex = 2,
                            MeasurementTime = new DateTime(2024, 6, 21, 1, 54, 11, 688, DateTimeKind.Local).AddTicks(7618),
                            MeterSerialNo = "aaAa11aa",
                            VoltageValue = 10.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
