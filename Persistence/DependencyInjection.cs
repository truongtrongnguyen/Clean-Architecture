using Application.Data;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence (this IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}
