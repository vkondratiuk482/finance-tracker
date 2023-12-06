using FinanceTracker.Domain.Budgets;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

public class EfCoreCurrencyRepository : ICurrencyRepository
{
    private readonly ApplicationContext _applicationContext;

    public EfCoreCurrencyRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Currency?> GetByIdAsync(Guid id)
    {
        return await _applicationContext.Currencies.Where(currency => currency.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Currency>> GetAsync()
    {
        return await _applicationContext.Currencies.ToListAsync();
    }
}
