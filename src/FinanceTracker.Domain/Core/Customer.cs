using FinanceTracker.Domain.Core.Enums;
using FinanceTracker.Domain.Core.ValueObjects;

namespace FinanceTracker.Domain.Core;

public class Customer
{
    public CustomerId Id { get; init; }

    private readonly List<Budget> _budgets;

    /**
     * .AsReadOnly() covers the following scenario:
     * (customer.Budgets as List<Budget>).Clear()
     */
    public IReadOnlyList<Budget> Budgets => _budgets.AsReadOnly();

    public Email Email { get; private set; }

    private ITaxationStrategy TaxationStrategy { get; set; }

    public Customer(TaxationTypes taxationType, Email email)
    {
        Id = new CustomerId(Guid.NewGuid());
        Email = email;
        _budgets = new List<Budget>();
        TaxationStrategy = TaxationStrategyFactory.Create(taxationType);
    }

    public void AddBudget(Budget budget)
    {
        _budgets.Add(budget);
    }

    public void RemoveBudget(Budget budget)
    {
        _budgets.Remove(budget);
    }

    public void UpdateTaxationStrategy(TaxationTypes taxationType)
    {
        TaxationStrategy = TaxationStrategyFactory.Create(taxationType);
    }
    
    public int CalculateTotalNet(int index)
    {
        var budget = _budgets[index];
        var income = budget.CalculateTotalIncome();

        return income - TaxationStrategy.Calculate(income);
    }
}
