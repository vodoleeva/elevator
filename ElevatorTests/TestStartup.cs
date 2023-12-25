using System.Reflection;
using ElevatorApp.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ElevatorApp.Services;

namespace ElevatorTests;

public class TestStartup
{
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddApplicationPart(Assembly.Load("ElevatorApi"))
            .AddControllersAsServices();
        
        services.AddScoped<ElevatorService>();
        services.AddScoped<ElevatorRepo>();
        
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
