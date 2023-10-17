namespace FinanceTracker.Domain.Budgets;

public interface IPiggyBankRepository
{
    Task<PiggyBank?> GetById(Guid id);
    
    Task AddAsync(PiggyBank piggyBank);
}
