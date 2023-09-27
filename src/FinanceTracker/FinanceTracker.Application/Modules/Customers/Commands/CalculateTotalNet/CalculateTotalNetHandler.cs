using FinanceTracker.Domain.Customers;
using FinanceTracker.Application.Common;

namespace FinanceTracker.Application.Modules.Customers.Commands.CalculateTotalNet;

public class CalculateTotalNetHandler : IHandler<CalculateTotalNetCommand, Task<int>>
{
    private readonly ICustomerRepository _customerRepository;

    public CalculateTotalNetHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<int> Handle(CalculateTotalNetCommand command)
    {
        var customer = await _customerRepository.GetById(command.CustomerId);

        return customer.CalculateTotalNet(command.BudgetId);
    }
}
