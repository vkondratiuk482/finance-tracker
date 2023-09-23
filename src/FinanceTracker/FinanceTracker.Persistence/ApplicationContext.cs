using FinanceTracker.Domain.Budgets;
using FinanceTracker.Domain.Customers;
using FinanceTracker.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Persistence;

public class ApplicationContext : DbContext
{
    public DbSet<Budget> Budgets => Set<Budget>();
    public DbSet<Customer> Customers => Set<Customer>();

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        new CustomerEntityTypeConfiguration().Configure(modelBuilder.Entity<Customer>());
        new BudgetEntityTypeConfiguration().Configure(modelBuilder.Entity<Budget>());
    }
}
