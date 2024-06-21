using MeterMicroservice.Application.Abstract;
using MeterMicroservice.Application.Concrete;
using MeterMicroservice.Infrastructure.Abstract;
using MeterMicroservice.Infrastructure.Concrete.EntityFramework;
using MeterMicroservice.Infrastructure.Concrete.EntityFramework.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        // Configuration settings can be added here if needed
                    })
                    .ConfigureServices((hostContext, services) =>
                    {
                        var connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");

                        services.AddControllers();
                        services.AddEndpointsApiExplorer();
                        services.AddSwaggerGen();
                        services.AddDbContext<AppDbContext>(options =>
                            options.UseSqlServer(connectionString));

                        // CORS policy
                        services.AddCors(options =>
                        {
                            options.AddPolicy("AllowSpecificOrigin",
                                builder =>
                                {
                                    builder.AllowAnyOrigin()
                                           .AllowAnyHeader()
                                           .AllowAnyMethod();
                                });
                        });

                        // Manager Dependency
                        services.AddScoped<IMeterService, MeterManager>();

                        // DAL Repo Dependency
                        services.AddScoped<IMeterDal, EfMeterDal>();
                    })
                    .Configure(app =>
                    {
                        var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                            app.UseSwagger();
                            app.UseSwaggerUI();
                        }

                        app.UseHttpsRedirection();

                        app.UseRouting();

                        // CORS politikasýný ekleyin
                        app.UseCors("AllowSpecificOrigin");

                        app.UseAuthorization();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
            });
}
