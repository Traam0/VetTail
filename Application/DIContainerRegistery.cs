using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using VetTail.Application.Common.Interfaces;
using VetTail.Application.Services;

namespace VetTail.DIRegistery;

public static partial class DIContainerRegistery
{
    public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program).Assembly);
        services.AddValidatorsFromAssembly(typeof(Program).Assembly);

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IProductsService, ProductsService>();
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}
