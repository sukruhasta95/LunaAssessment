using Microsoft.EntityFrameworkCore;
using ReportMicroservice.Application.Abstract;
using ReportMicroservice.Application.Concrete;
using ReportMicroservice.Infrastructure.Abstract;
using ReportMicroservice.Infrastructure.Concrete.EntityFramework;
using ReportMicroservice.Infrastructure.Concrete.EntityFramework.Context;
using Wolverine;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
builder.Host.UseWolverine(x =>
{
    x.UseRabbitMq(new Uri("amqps://jswqdvpj:5Vvc0aJcgSQN3nQjazWocLPwxpZIDyNq@rat.rmq2.cloudamqp.com/jswqdvpj"));
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

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
