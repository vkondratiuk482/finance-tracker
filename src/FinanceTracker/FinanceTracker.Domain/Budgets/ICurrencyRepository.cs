namespace FinanceTracker.Domain.Budgets;

public interface ICurrencyRepository
{
    Task<Currency?> GetById(Guid id);
}
