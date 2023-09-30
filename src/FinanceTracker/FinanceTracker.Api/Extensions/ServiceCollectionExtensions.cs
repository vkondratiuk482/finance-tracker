using FinanceTracker.Application.Modules.Customers.Commands.CreateCustomer;
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
            .AddPersistenceLayer(configuration)
            .AddApiLayer()
            .AddApplicationLayer();
    }

    private static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();

        return services;
    }

    private static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            Console.WriteLine(assembly.FullName);
        }

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).Assembly));
        
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
