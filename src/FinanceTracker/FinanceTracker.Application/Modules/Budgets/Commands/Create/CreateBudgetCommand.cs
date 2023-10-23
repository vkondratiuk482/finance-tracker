using MediatR;

namespace FinanceTracker.Application.Modules.Budgets.Commands.Create;

public class CreateBudgetCommand : IRequest<Guid>
{
    public Guid CustomerId { get; set; }
    
    public Guid CurrencyId { get; set; }

    public int Payday { get; set; }
}
