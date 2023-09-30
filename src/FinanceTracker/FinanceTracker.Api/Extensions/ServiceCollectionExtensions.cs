using System.Reflection;
using System.Text.Json.Serialization;
using FinanceTracker.Domain.Customers;
using FinanceTracker.Persistence;
using FinanceTracker.Persistence.Repositories;

namespace FinanceTracker.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEverything(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        return services
            .AddApiLayer()
            .AddApplicationLayer()
            .AddPersistenceLayer(configuration);
    }

    private static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        
        services.AddSwaggerGen();

        return services;
    }

    private static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        Assembly.Load("FinanceTracker.Application");

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

        return services;
    }

    private static IServiceCollection AddPersistenceLayer(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var postgresHost = configuration["Postgres:Host"];
        var postgresPort = configuration["Postgres:Port"];
        var postgresDatabase = configuration["Postgres:Database"];
        var postgresUser = configuration["Postgres:User"];
        var postgresPassword = configuration["Postgres:Password"];

        var connectionString =
            $"Host={postgresHost};Port={postgresPort};Database={postgresDatabase};Username={postgresUser};Password={postgresPassword}";

        services.AddNpgsql<ApplicationContext>(connectionString);

        services.AddScoped<ICustomerRepository, EfCoreCustomerRepository>();

        return services;
    }
}
