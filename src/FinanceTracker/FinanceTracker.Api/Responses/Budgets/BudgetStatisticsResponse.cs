namespace FinanceTracker.Api.Responses.Budgets;

public sealed class BudgetStatisticsResponse
{
    public decimal Netto { get; set; }

    public decimal Brutto { get; set; }

    public decimal MoneyLeft { get; set; }
    
    public decimal Savings { get; set; }

    public decimal AuthorizedDailyExpenses { get; set; }
}
