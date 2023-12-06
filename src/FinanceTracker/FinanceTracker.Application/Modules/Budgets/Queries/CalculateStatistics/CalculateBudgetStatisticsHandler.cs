using MediatR;
using FinanceTracker.Domain.Budgets;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Modules.Budgets.Queries.CalculateStatistics;

public sealed class
    CalculateBudgetStatisticsHandler : IRequestHandler<CalculateBudgetStatisticsQuery, BudgetStatistics>
{
    private readonly ICurrencyClient _currencyClient;
    private readonly IBudgetRepository _budgetRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ICurrencyRepository _currencyRepository;

    public CalculateBudgetStatisticsHandler(ICustomerRepository customerRepository,
        IBudgetRepository budgetRepository, ICurrencyRepository currencyRepository,
        ICurrencyClient currencyClient)
    {
        _currencyClient = currencyClient;
        _budgetRepository = budgetRepository;
        _customerRepository = customerRepository;
        _currencyRepository = currencyRepository;
    }

    public async Task<BudgetStatistics> Handle(CalculateBudgetStatisticsQuery query,
        CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(query.CustomerId);

        var budget = await _budgetRepository.GetById(query.BudgetId);

        decimal rate = 1; 
        
        if (query.CurrencyId != budget.CurrencyId)
        {
            var sourceTask = _currencyRepository.GetByIdAsync(budget.CurrencyId);
            var targetTask = _currencyRepository.GetByIdAsync(query.CurrencyId);

            await Task.WhenAll(sourceTask, targetTask);

            var currencyRate = await _currencyClient.GetRateAsync(sourceTask.Result, targetTask.Result);

            // Decide which rate to take
            // Test it out in practice
            rate = currencyRate.Buy;
        }

        return new BudgetStatistics
        {
            Brutto = budget.CalculateTotalIncome() / rate,
            Savings = budget.CalculateTotalSavings() / rate,
            Netto = budget.CalculateTotalNetto(customer) / rate,
            MoneyLeft = budget.CalculateMoneyLeft(customer) / rate,
            AuthorizedDailyExpenses = budget.CalculateAuthorizedDailyExpenses(customer, query.UpTo) / rate,
        };
    }
}
