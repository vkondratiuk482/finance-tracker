using FinanceTracker.Application.Common;

namespace FinanceTracker.Application.Modules.Customers.Commands.CalculateTotalNet;

public class CalculateTotalNetCommand : ICommand
{
    public Guid CustomerId { get; set; }
    
    public Guid BudgetId { get; set; }
}
