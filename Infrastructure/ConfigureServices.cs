﻿using System;
namespace Microsoft.Extensions.DependencyInjection;
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

        //services.AddScoped<ApplicationDbContextInitialiser>();

        //services
        //    .AddDefaultIdentity<ApplicationUser>()
        //    //.AddRoles<IdentityRole>()
        //    .AddEntityFrameworkStores<ApplicationDbContext>();

        ////services.AddIdentityServer()
        ////    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        //services.AddTransient<IDateTime, DateTimeService>();
        ////services.AddTransient<IIdentityService, IdentityService>();
        ////services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        ////services.AddAuthentication()
        ////    .AddIdentityServerJwt();

        ////services.AddAuthorization(options =>
        ////    options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        //return services;


        //services.AddAuthorizationPolicies();

        return services;
    }
}