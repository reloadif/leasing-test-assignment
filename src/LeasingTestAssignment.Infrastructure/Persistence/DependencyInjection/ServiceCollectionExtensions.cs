using LeasingTestAssignment.Domain.Interfaces;
using LeasingTestAssignment.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeasingTestAssignment.Infrastructure.Persistence.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LeasingTestAssignmentDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LeasingTestAssignmentDbContextConnection")));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IOfferRepository, OfferRepository>();

        return services;
    }
}
