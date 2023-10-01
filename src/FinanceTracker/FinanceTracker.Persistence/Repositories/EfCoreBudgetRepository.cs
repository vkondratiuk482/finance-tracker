using FinanceTracker.Domain.Budgets;

namespace FinanceTracker.Persistence.Repositories;

public class EfCoreBudgetRepository : IBudgetRepository
{
    private readonly ApplicationContext _applicationContext;

    public EfCoreBudgetRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task AddAsync(Budget budget)
    {
        await _applicationContext.Budgets.AddAsync(budget);
        await _applicationContext.SaveChangesAsync();
    }
}
