using FinanceTracker.Domain.Budgets;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

public class EfCoreBudgetRepository : IBudgetRepository
{
    private readonly ApplicationContext _applicationContext;

    public EfCoreBudgetRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Budget?> GetById(Guid id)
    {
        return await _applicationContext.Budgets
            .Where(budget => budget.Id == id)
            .Include(budget => budget.Categories)
            .ThenInclude(category => category.Sources)
            .Include(budget => budget.PiggyBanks)
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(Budget budget)
    {
        await _applicationContext.Budgets.AddAsync(budget);
        await _applicationContext.SaveChangesAsync();
    }
}
