namespace FinanceTracker.Application.Modules.Budgets.Queries.CalculateStatistics;

public class BudgetStatistics
{
    public int Netto { get; set; }

    public int Brutto { get; set; }

    public int MoneyLeft { get; set; }
    
    public double AuthorizedDailyExpenses { get; set; }
}
