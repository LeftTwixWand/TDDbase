using System.Reflection;
using CloudCustomers.Infrastructure.Interfaces;
using CloudCustomers.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CloudCustomers.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureMappings(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
    
    // TODO: Add Repository for Dongle 

    public static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddTransient(typeof(IRepositoryAsync<,>), typeof(RepositoryAsync<,>))
                .AddTransient<IDongleRepository, DongleRepository>()
            .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
    }
}