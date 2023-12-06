namespace FinanceTracker.Infrastructure.Clients.Monobank.Responses;

public sealed class MonobankCurrencyRateResponse
{
    public int CurrencyCodeA { get; set; }
    
    public int CurrencyCodeB { get; set; }
    
    public decimal RateBuy { get; set; }
    
    public decimal RateSell { get; set; }
}
