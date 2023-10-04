namespace FinanceTracker.Domain.Budgets;

public interface ISourceRepository
{
    Task AddAsync(Source source);
}
