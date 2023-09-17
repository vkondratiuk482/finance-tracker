using FinanceTracker.Application.Common;
using FinanceTracker.Domain.Core.Enums;

namespace FinanceTracker.Application.Modules.Customer.Commands.CreateCustomer;

public class CreateCustomerCommand : ICommand
{
    public string Id { get; }
    
    public string Email { get; set; }

    public TaxationTypes TaxationType { get; set; }
}
