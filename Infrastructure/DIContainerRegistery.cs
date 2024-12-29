using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using VetTail.Domain.Common.Interfaces;
using VetTail.Domain.Entities;
using VetTail.Infrastructure.Common.Repositories;
using VetTail.Infrastructure.Data.Interceptors;
using VetTail.Infrastructure.Data.Persistance;

namespace VetTail.DIRegistery;

public static partial class DIContainerRegistery
{
    public static IServiceCollection RegisterInfrastructureLayer(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.RegisterDataBaseContxet(configuration);
        services.AddIdentity<User, IdentityRole<ulong>>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
        })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "Vetail.ATS";
            options.ExpireTimeSpan = TimeSpan.FromDays(1);
            options.Cookie.HttpOnly = true;
            options.LoginPath = "/auth/login";
            options.LogoutPath = "/auth/logout";
            options.AccessDeniedPath = "/auth/denied";
            options.SlidingExpiration = true;
        });

        return services;
    }

    private static IServiceCollection RegisterDataBaseContxet(this IServiceCollection services, ConfigurationManager configuration) 
    {
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            string? connectionString = configuration.GetConnectionString("SqlServer") ;

            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentException("missing connection string: SqlServer from");
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        });

        return services;
    }
}
