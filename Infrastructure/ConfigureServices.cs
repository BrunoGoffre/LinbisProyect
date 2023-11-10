using Application.Interfaces;
using Database;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;


namespace Microsoft.Extensions.DependencyInjection;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IFileProyects, FileProyects>();
        services.AddTransient<IFileDevelopers, FileDevelopers>();
        services.AddTransient<IDevelopersService, DevelopersService>();
        services.AddTransient<IProyectService, ProyectService>();

        return services;
    }
}