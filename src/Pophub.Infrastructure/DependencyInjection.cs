using Microsoft.Extensions.DependencyInjection;
using Pophub.Application.Common.Repositories;
using Pophub.Infrastructure.Data;
using Pophub.Infrastructure.Data.Repositories;

namespace Pophub.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(
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
