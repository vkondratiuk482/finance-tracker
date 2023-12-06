namespace FinanceTracker.Api.Responses.Budgets;

public sealed class CurrencyResponse
{
    public Guid Id { get; set; }

    public string Iso4217Code { get; set; }

    public int Iso4217Num { get; set; }
}
