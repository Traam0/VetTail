using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using VetTail.Infrastructure.Data.Persistance;

namespace VetTail.Infrastructure;

public static partial class DIContainerRegistery
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {

        services.RegisterDataBaseContxet(configuration);
        return services;
    }

    private static IServiceCollection RegisterDataBaseContxet(this IServiceCollection services, ConfigurationManager configuration) 
    {
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            string? connectionString = configuration.GetConnectionString("SqlServer") ;

            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentException("missing connection string: SqlServer from");

            options.UseSqlServer(connectionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        });

        return services;
    }
}
