using MediatR;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Modules.Customers.Commands.CalculateTotalNet;

public sealed class CalculateTotalNetHandler : IRequestHandler<CalculateTotalNetCommand, int>
{
    private readonly ICustomerRepository _customerRepository;

    public CalculateTotalNetHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<int> Handle(CalculateTotalNetCommand command, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(command.CustomerId);

        return customer.CalculateTotalNet(command.BudgetId);
    }
}
