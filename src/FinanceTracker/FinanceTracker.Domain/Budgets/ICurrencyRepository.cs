namespace FinanceTracker.Domain.Budgets;

public interface ICurrencyRepository
{
    Task<Currency?> GetByIdAsync(Guid id);
    
    Task<List<Currency>> GetAsync();
}
