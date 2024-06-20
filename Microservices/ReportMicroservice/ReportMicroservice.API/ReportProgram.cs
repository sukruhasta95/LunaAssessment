using Microsoft.EntityFrameworkCore;
using ReportMicroservice.Application.Abstract;
using ReportMicroservice.Application.Concrete;
using ReportMicroservice.Infrastructure.Abstract;
using ReportMicroservice.Infrastructure.Concrete.EntityFramework;
using ReportMicroservice.Infrastructure.Concrete.EntityFramework.Context;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

//Manager Dependency
builder.Services.AddSingleton(typeof(IReportService), typeof(ReportManager));

//DAL Repo Dependecy
builder.Services.AddSingleton(typeof(IReportDal), typeof(EfReportDal));

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
