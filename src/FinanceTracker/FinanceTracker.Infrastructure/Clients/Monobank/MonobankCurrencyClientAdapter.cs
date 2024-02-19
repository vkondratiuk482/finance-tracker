using FinanceTracker.Domain.Budgets;
using FinanceTracker.Domain.Common;
using FinanceTracker.Infrastructure.Clients.Monobank.Responses;

namespace FinanceTracker.Infrastructure.Clients.Monobank;

public class MonobankCurrencyClientAdapter : ICurrencyClient
{
    private readonly ICacheService _cacheService;
    private readonly MonobankClient _monobankClient;
    
    private const string CachingKey = "monobank:currencies";

    public MonobankCurrencyClientAdapter(MonobankClient monobankClient, ICacheService cacheService)
    {
        _cacheService = cacheService;
        _monobankClient = monobankClient;
    }

    public async Task<CurrencyRate> GetRateAsync(Currency source, Currency target)
    {
        List<MonobankCurrencyRateResponse> rates;
        
        rates = await _cacheService.GetAsync<List<MonobankCurrencyRateResponse>>(CachingKey);

        if (rates is null)
        {
            rates = await _monobankClient.GetRateAsync();
            
            await _cacheService.SetAsync(CachingKey, rates, TimeSpan.FromMinutes(10));
        }
        
        foreach (var rate in rates)
        {
            if (rate.CurrencyCodeA == source.Iso4217Num &&
                rate.CurrencyCodeB == target.Iso4217Num)
            {
                return new CurrencyRate(source, target, rate.RateSell, rate.RateBuy);
            }

            if (rate.CurrencyCodeA == target.Iso4217Num &&
                rate.CurrencyCodeB == source.Iso4217Num)
            {
                return new CurrencyRate(source, target, 1 / rate.RateSell, 1 / rate.RateBuy);
            }
        }

        // Refactor
        throw new Exception("You have provided invalid pair of currencies");
    }
}
