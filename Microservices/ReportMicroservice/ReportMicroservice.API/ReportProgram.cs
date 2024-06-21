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
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
//Manager Dependency
builder.Services.AddScoped(typeof(IReportService), typeof(ReportManager));

//DAL Repo Dependecy
builder.Services.AddScoped(typeof(IReportDal), typeof(EfReportDal));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
