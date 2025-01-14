using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace VetTail.DIRegistery;

public static partial class DIContainerRegistery
{
    public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program).Assembly);
        services.AddValidatorsFromAssembly(typeof(Program).Assembly);

        return services;
    }
}
