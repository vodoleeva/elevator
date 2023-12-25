using ElevatorApp.DataAccess;
using ElevatorApp.Entities;
using ElevatorApp.Interfaces;
using ElevatorApp.Services;
using ElevatorApp.Services.Passenger;
using Microsoft.OpenApi.Models;

namespace ElevatorApp;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<ElevatorRepo>();
        services.AddScoped<ElevatorService>();
        services.AddScoped<IPassengerRepo, PassengerRepo>();
        services.AddScoped<IPassengerService, PassengerService>();


        services.AddSingleton<Engine>();
        
        

        services.AddControllers();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Elevator Service",
                Description = "Backend Service for Elevators."
            });
        });
        
        services.AddCors(options =>
        {
            options.AddPolicy("ClientPermission", policy =>
            {
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:3000")
                    .AllowCredentials();
            });
        });
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        app.UseSwagger();
        app.UseSwaggerUI(ui =>
        {
            ui.SwaggerEndpoint("swagger/v1/swagger.json", "Elevator");
            ui.RoutePrefix = string.Empty;
        });
        
        app.UseHttpsRedirection();
        
        app.UseCors("ClientPermission");
        
        app.UseRouting();
        
    }


}
