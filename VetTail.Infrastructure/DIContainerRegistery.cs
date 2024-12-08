using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VetTail.Domain.Common.Interfaces;
using VetTail.Infrastructure.Common.Repositories;
using VetTail.Infrastructure.Data.Interceptors;
using VetTail.Infrastructure.Data.Persistence;

namespace VetTail.Infrastructure;

public static class DIContainerRegistery
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddKeyedScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>(nameof(AuditableEntityInterceptor));
        services.AddKeyedScoped<ISaveChangesInterceptor, EventDispatcherInterceptor>(nameof(EventDispatcherInterceptor));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        services.RegisterSqlServerContext(configuration);
        return services;
    }

    private static IServiceCollection RegisterSqlServerContext(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            string connectionString = configuration.GetConnectionString("SqlServer") ?? throw new ArgumentNullException("Missing SqlServer Connection string.");
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        });
        return services;
    }
}
