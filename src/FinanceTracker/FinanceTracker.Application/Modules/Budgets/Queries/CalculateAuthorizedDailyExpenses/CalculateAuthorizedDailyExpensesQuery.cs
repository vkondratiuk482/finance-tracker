using MediatR;

namespace FinanceTracker.Application.Modules.Budgets.Queries.CalculateAuthorizedDailyExpenses;

public class CalculateAuthorizedDailyExpensesQuery : IRequest<double>
{
    public Guid CustomerId { get; set; }

    public Guid BudgetId { get; set; }

    public DateTime? UpTo { get; set; }
}
