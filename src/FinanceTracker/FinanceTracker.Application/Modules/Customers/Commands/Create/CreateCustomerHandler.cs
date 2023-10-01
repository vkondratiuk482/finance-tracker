using MediatR;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Modules.Customers.Commands.Create;

public sealed class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = new Customer(command.TaxationType, new Email(command.Email));

        await _customerRepository.AddAsync(customer);
    }
}
