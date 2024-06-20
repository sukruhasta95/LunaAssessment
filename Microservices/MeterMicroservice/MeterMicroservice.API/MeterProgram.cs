using MeterMicroservice.Application.Abstract;
using MeterMicroservice.Application.Concrete;
using MeterMicroservice.Infrastructure.Abstract;
using MeterMicroservice.Infrastructure.Concrete.EntityFramework;
using MeterMicroservice.Infrastructure.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

//Manager Dependency
builder.Services.AddSingleton(typeof(IMeterService),typeof(MeterManager));

//DAL Repo Dependecy
builder.Services.AddSingleton(typeof(IMeterDal),typeof(EfMeterDal));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
