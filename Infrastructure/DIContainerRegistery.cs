using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using VetTail.Domain.Common.Interfaces;
using VetTail.Infrastructure.Common.Repositories;
using VetTail.Infrastructure.Data.Interceptors;
using VetTail.Infrastructure.Data.Persistance;

namespace VetTail.Infrastructure;

public static partial class DIContainerRegistery
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.RegisterDataBaseContxet(configuration);
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
