using FinanceTracker.Domain.Customers;
using FinanceTracker.Application.Common;

namespace FinanceTracker.Application.Modules.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand : ICommand
{
    public string Email { get; set; }

    public TaxationTypes TaxationType { get; set; }
}
