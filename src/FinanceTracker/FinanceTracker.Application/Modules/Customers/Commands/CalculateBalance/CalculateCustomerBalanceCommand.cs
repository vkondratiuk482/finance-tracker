using MediatR;

namespace FinanceTracker.Application.Modules.Customers.Commands.CalculateBalance;

public class CalculateCustomerBalanceCommand : IRequest<CustomerBalance>
{
    public Guid CustomerId { get; set; }
    
    public Guid BudgetId { get; set; }
}
