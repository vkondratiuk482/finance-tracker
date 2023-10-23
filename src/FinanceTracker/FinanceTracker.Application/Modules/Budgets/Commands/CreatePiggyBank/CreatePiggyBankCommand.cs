using MediatR;

namespace FinanceTracker.Application.Modules.Budgets.Commands.CreatePiggyBank;

public class CreatePiggyBankCommand : IRequest<Guid>
{
    public Guid BudgetId { get; set; }

    public string Name { get; set; }

    public int ExpectedAmount { get; set; }

    public DateTime UpTo { get; set; }
}
