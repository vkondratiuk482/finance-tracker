using MediatR;
using FinanceTracker.Domain.Budgets;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Modules.Budgets.Queries.CalculateStatistics;

public sealed class
    CalculateBudgetStatisticsHandler : IRequestHandler<CalculateBudgetStatisticsQuery, BudgetStatistics>
{
    private readonly IBudgetRepository _budgetRepository;
    private readonly ICustomerRepository _customerRepository;

    public CalculateBudgetStatisticsHandler(ICustomerRepository customerRepository,
        IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
        _customerRepository = customerRepository;
    }

    public async Task<BudgetStatistics> Handle(CalculateBudgetStatisticsQuery query,
        CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(query.CustomerId);

        var budget = await _budgetRepository.GetById(query.BudgetId);

        return new BudgetStatistics
        {
            Brutto = budget.CalculateTotalIncome(),
            Netto = budget.CalculateTotalNetto(customer),
            MoneyLeft = budget.CalculateMoneyLeft(customer),
            AuthorizedDailyExpenses = budget.CalculateAuthorizedDailyExpenses(customer, query.UpTo),
        };
    }
}
