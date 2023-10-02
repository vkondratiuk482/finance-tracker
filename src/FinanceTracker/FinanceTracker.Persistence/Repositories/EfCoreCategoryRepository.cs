using FinanceTracker.Domain.Budgets;

namespace FinanceTracker.Persistence.Repositories;

public class EfCoreCategoryRepository : ICategoryRepository
{
    private readonly ApplicationContext _applicationContext;

    public EfCoreCategoryRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task AddAsync(Category category)
    {
        await _applicationContext.Categories.AddAsync(category);
        await _applicationContext.SaveChangesAsync();
    }
}
