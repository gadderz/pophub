using Microsoft.Extensions.DependencyInjection;
using Pophub.Application.Common.Repositories;
using Pophub.Persistence.Data;
using Pophub.Persistence.Data.Repositories;

namespace Pophub.Persistence.DependencyInjection;

public static class DependencyInjection
{
    public static void AddPersistenceServices(
        this IServiceCollection services,
        string connectionString,
        string? migratrionAssembly = null
    )
    {
        services.AddApplicationDbContext(connectionString, migratrionAssembly);

        services.AddScoped<IGameCategoryRepository, GameCategoryRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
    }
}
