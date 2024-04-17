using Microsoft.Extensions.DependencyInjection;

namespace VirtualBookstore.Infrastructure.DataAccess;

public static class DataAccessSetup
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(
            options => options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

        return services;
    }
}