using FinanceTracker.Domain.Budgets;

namespace FinanceTracker.Infrastructure.Clients.Monobank;

public class MonobankCurrencyClientAdapter : ICurrencyClient
{
    private readonly MonobankClient _monobankClient;

    public MonobankCurrencyClientAdapter(MonobankClient monobankClient)
    {
        _monobankClient = monobankClient;
    }

    public async Task<CurrencyRate> GetRateAsync(Currency source, Currency target)
    {
        var monobankRates = await _monobankClient.GetRateAsync();

        foreach (var monobankRate in monobankRates)
        {
            if (monobankRate.CurrencyCodeA == source.Iso4217Num &&
                monobankRate.CurrencyCodeB == target.Iso4217Num)
            {
                return new CurrencyRate(source, target, monobankRate.RateSell, monobankRate.RateBuy);
            }

            if (monobankRate.CurrencyCodeA == target.Iso4217Num &&
                monobankRate.CurrencyCodeB == source.Iso4217Num)
            {
                return new CurrencyRate(source, target, 1 / monobankRate.RateSell, 1 / monobankRate.RateBuy);
            }
        }

        // Refactor
        throw new Exception("You have provided invalid pair of currencies");
    }
}
