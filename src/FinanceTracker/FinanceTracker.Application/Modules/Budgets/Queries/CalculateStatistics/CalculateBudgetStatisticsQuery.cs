using MediatR;

namespace FinanceTracker.Application.Modules.Budgets.Queries.CalculateStatistics;

public class CalculateBudgetStatisticsQuery : IRequest<BudgetStatistics>
{
    public Guid CustomerId { get; set; }

    public Guid BudgetId { get; set; }

    public DateTime? UpTo { get; set; }
}
