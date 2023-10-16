namespace FinanceTracker.Api.Responses.Budgets;

public sealed class BudgetStatisticsResponse
{
    public int Netto { get; set; }

    public int Brutto { get; set; }

    public int MoneyLeft { get; set; }
    
    public int Savings { get; set; }

    public double AuthorizedDailyExpenses { get; set; }
}
