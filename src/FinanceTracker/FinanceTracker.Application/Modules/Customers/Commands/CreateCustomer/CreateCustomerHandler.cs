using FinanceTracker.Application.Common;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Modules.Customers.Commands.CreateCustomer;

public class CreateCustomerHandler : IHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(CreateCustomerCommand command)
    {
        var customer = new Customer(command.TaxationType, new Email(command.Email));

        await _customerRepository.AddAsync(customer);
    }
}
