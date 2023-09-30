using MediatR;

namespace FinanceTracker.Application.Modules.Customers.Commands.CalculateTotalNet;

public class CalculateTotalNetCommand : IRequest<int>
{
    public Guid CustomerId { get; set; }
    
    public Guid BudgetId { get; set; }
}
