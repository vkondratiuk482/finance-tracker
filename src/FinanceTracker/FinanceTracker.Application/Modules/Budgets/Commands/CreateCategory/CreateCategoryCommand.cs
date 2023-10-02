using MediatR;

namespace FinanceTracker.Application.Modules.Budgets.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<Guid>
{
    public Guid BudgetId { get; set; }

    public string Name { get; set; }
}
