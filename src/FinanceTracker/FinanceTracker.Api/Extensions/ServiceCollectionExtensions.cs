using System.Reflection;
using System.Text.Json.Serialization;
using FinanceTracker.Domain.Budgets;
using FinanceTracker.Domain.Common;
using FinanceTracker.Domain.Customers;
using FinanceTracker.Infrastructure.Cache;
using FinanceTracker.Infrastructure.Clients.Monobank;
using FinanceTracker.Infrastructure.Persistence;
using FinanceTracker.Infrastructure.Persistence.Repositories;
using StackExchange.Redis;

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
        services.AddScoped<HttpClient>();
        services.AddScoped<MonobankClient>();
        services.AddScoped<ICurrencyClient, MonobankCurrencyClientAdapter>();

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
        
        var redisConfigOptions = new ConfigurationOptions
        {
            Password = configuration["Redis:Password"],
            EndPoints = { configuration["Redis:EndPoint"], },
        };

        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConfigOptions));
        services.AddScoped<ICacheService, RedisCacheService>();

        services.AddScoped<ICustomerRepository, EfCoreCustomerRepository>();
        services.AddScoped<IBudgetRepository, EfCoreBudgetRepository>();
        services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
        services.AddScoped<ISourceRepository, EfCoreSourceRepository>();
        services.AddScoped<IPiggyBankRepository, EfCorePiggyBankRepository>();
        services.AddScoped<ICurrencyRepository, EfCoreCurrencyRepository>();

        return services;
    }
}
