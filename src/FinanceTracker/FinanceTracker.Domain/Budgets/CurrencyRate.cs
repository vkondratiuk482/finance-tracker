namespace FinanceTracker.Domain.Budgets;

public class CurrencyRate
{
    public Currency Source { get; private set; }

    public Currency Target { get; private set; }

    public decimal Sell { get; private set; }

    public decimal Buy { get; private set; }

    public CurrencyRate(Currency source, Currency target, decimal sell, decimal buy)
    {
        Buy = buy;
        Sell = sell;
        Source = source;
        Target = target;
    }
}
