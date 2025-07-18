using LeasingTestAssignment.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LeasingTestAssignment.Application.Services.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<IOfferService, OfferService>();

        return services;
    }
}
