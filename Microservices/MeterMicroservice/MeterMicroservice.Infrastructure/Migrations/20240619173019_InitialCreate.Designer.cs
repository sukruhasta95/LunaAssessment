﻿// <auto-generated />
using System;
using MeterMicroservice.Infrastructure.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeterMicroservice.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240619173019_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MeterMicroservice.Entity.Meter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                            Id = new Guid("3e44d10d-6ad0-4081-9db2-ed9226715552"),
                            CreatedOn = new DateTime(2024, 6, 19, 20, 30, 19, 504, DateTimeKind.Local).AddTicks(8423),
                            CurrentValue = 10.0,
                            IsDeleted = false,
                            LastIndex = 2,
                            MeasurementTime = new DateTime(2024, 6, 19, 20, 30, 19, 504, DateTimeKind.Local).AddTicks(8439),
                            MeterSerialNo = "aaAa11aa",
                            VoltageValue = 10.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}