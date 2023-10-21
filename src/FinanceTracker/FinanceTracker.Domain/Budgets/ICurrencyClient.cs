namespace FinanceTracker.Domain.Budgets;

public interface ICurrencyClient
{
    Task<CurrencyRate?> GetRateAsync(Currency source, Currency target);
}
