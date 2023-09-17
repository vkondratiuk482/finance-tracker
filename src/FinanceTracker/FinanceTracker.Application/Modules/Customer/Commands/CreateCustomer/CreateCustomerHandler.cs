using FinanceTracker.Domain.Core;
using FinanceTracker.Application.Common;
using FinanceTracker.Domain.Core.ValueObjects;

namespace FinanceTracker.Application.Modules.Customer.Commands.CreateCustomer;

public class CreateCustomerHandler : IHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(CreateCustomerCommand command)
    {
        // figure out why doesn't it work as expected
        var customer = new Domain.Core.Customer(command.TaxationType, new Email(command.Email));

        await _customerRepository.AddAsync(customer);
    }
}
