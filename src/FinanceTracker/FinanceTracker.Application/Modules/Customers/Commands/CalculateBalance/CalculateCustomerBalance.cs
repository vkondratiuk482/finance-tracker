using MediatR;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Modules.Customers.Commands.CalculateBalance;

public sealed class CalculateCustomerBalanceHandler : IRequestHandler<CalculateCustomerBalanceCommand, CustomerBalance>
{
    private readonly ICustomerRepository _customerRepository;

    public CalculateCustomerBalanceHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerBalance> Handle(CalculateCustomerBalanceCommand command, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(command.CustomerId);

        return new CustomerBalance
        {
            Netto = customer.CalculateTotalNetto(command.BudgetId),
            Brutto = customer.CalculateTotalBrutto(command.BudgetId),
            MoneyLeft = customer.CalculateMoneyLeft(command.BudgetId)
        };
    }
}
