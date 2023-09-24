using FinanceTracker.Domain.Customers;
using FinanceTracker.Application.Common;

namespace FinanceTracker.Application.Modules.Customers.Commands.UpdateCustomerTaxationType;

public class UpdateCustomerTaxationTypeCommand : ICommand
{
    public Guid Id { get; set; }

    public TaxationTypes TaxationType { get; set; }
}
