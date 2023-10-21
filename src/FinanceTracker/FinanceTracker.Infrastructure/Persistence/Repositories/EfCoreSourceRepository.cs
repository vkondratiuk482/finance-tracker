using FinanceTracker.Domain.Budgets;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

public class EfCoreSourceRepository : ISourceRepository
{
    private readonly ApplicationContext _applicationContext;

    public EfCoreSourceRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task AddAsync(Source source)
    {
        await _applicationContext.Sources.AddAsync(source);
        await _applicationContext.SaveChangesAsync();
    }
}
