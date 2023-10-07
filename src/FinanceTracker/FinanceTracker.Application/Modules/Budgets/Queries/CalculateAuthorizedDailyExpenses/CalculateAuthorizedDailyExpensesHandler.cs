using MediatR;
using FinanceTracker.Domain.Budgets;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Modules.Budgets.Queries.CalculateAuthorizedDailyExpenses;

public sealed class
    CalculateAuthorizedDailyExpensesHandler : IRequestHandler<CalculateAuthorizedDailyExpensesQuery, double>
{
    private readonly IBudgetRepository _budgetRepository;
    private readonly ICustomerRepository _customerRepository;

    public CalculateAuthorizedDailyExpensesHandler(ICustomerRepository customerRepository,
        IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
        _customerRepository = customerRepository;
    }

    public async Task<double> Handle(CalculateAuthorizedDailyExpensesQuery query, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(query.CustomerId);

        var budget = await _budgetRepository.GetById(query.BudgetId);
        
        return budget.CalculateAuthorizedDailyExpenses(customer, query.UpTo);
    }
}
