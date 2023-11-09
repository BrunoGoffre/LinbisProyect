using System;
namespace Microsoft.Extensions.DependencyInjection;

using Application.Interfaces;
using Database;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        //if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        //{
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseInMemoryDatabase("CRUDCleanArchitectureDb"));
        //}
        //else
        //{
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        //            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        //}

        //services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddTransient<IFileDevelopers, FileDevelopers>();
        services.AddTransient<IFileProyects, FileProyects>();
        services.AddTransient<IDevelopersService, DevelopersService>();
        services.AddTransient<IProyectService, ProyectService>();

        return services;
    }
}