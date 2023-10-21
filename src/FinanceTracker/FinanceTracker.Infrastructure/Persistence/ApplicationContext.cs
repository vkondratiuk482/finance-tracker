using Microsoft.EntityFrameworkCore;
using FinanceTracker.Domain.Budgets;
using FinanceTracker.Domain.Customers;
using FinanceTracker.Infrastructure.Persistence.EntityTypeConfigurations;

namespace FinanceTracker.Infrastructure.Persistence;

public class ApplicationContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Budget> Budgets => Set<Budget>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Source> Sources => Set<Source>();
    public DbSet<PiggyBank> PiggyBanks => Set<PiggyBank>();
    public DbSet<Currency> Currencies => Set<Currency>();

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BudgetEntityTypeConfiguration());
    }
}
