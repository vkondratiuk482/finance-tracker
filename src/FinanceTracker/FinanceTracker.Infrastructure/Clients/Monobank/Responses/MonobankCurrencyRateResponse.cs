namespace FinanceTracker.Infrastructure.Clients.Monobank.Responses;

public sealed class MonobankCurrencyRateResponse
{
    public int CurrencyCodeA { get; private set; }
    
    public int CurrencyCodeB { get; private set; }
    
    public DateTime Date { get; private set; }
    
    public decimal RateBuy { get; private set; }
    
    public decimal RateSell { get; private set; }
}
