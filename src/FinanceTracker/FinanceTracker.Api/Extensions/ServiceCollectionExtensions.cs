using FinanceTracker.Persistence;

namespace FinanceTracker.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, ConfigurationManager configuration)
    {
        return services.AddPersistence(configuration);
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
    {
        var postgresHost = configuration["Postgres:Host"];
        var postgresPort = configuration["Postgres:Port"];
        var postgresDatabase = configuration["Postgres:Database"];
        var postgresUser = configuration["Postgres:User"];
        var postgresPassword = configuration["Postgres:Password"];

        var connectionString =
            $"Host={postgresHost};Port={postgresPort};Database={postgresDatabase};Username={postgresUser};Password={postgresPassword}";
        
        services.AddNpgsql<ApplicationContext>(connectionString);

        return services;
    }
}
