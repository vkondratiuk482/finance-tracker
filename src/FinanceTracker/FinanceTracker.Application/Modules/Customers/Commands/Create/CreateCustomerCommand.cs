using MediatR;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Modules.Customers.Commands.Create;

public class CreateCustomerCommand : IRequest 
{
    public string Email { get; set; }

    public TaxationTypes TaxationType { get; set; }
}
