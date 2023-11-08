using System;
namespace Microsoft.Extensions.DependencyInjection;

using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDevelopersService, DevelopersService>();
        services.AddTransient<IProyectService, ProyectService>();

        return services;
    }
}