using FinanceTracker.Domain.Budgets;
using FinanceTracker.Domain.Common;
using FinanceTracker.Domain.Customers.Strategies;

namespace FinanceTracker.Domain.Customers;

public class Customer : AggregateRoot<CustomerId, Guid>
{
    private readonly List<Budget> _budgets;

    /**
     * .AsReadOnly() covers the following scenario:
     * (customer.Budgets as List<Budget>).Clear()
     */
    public IReadOnlyList<Budget> Budgets => _budgets.AsReadOnly();

    public Email Email { get; private set; }

    public TaxationTypes TaxationType { get; private set; }
    
    public Customer(TaxationTypes taxationType, Email email)
    {
        Id = new CustomerId(Guid.NewGuid());
        Email = email;
        TaxationType = taxationType;
        _budgets = new List<Budget>();
    }

    // Private constructor for EF Core
    private Customer()
    {
        
    }

    public void AddBudget(Budget budget)
    {
        _budgets.Add(budget);
    }

    public void RemoveBudget(Budget budget)
    {
        _budgets.Remove(budget);
    }

    public void UpdateTaxationType(TaxationTypes taxationType)
    {
        TaxationType = taxationType;
    }
    
    public int CalculateTotalNet(int index)
    {
        var budget = _budgets[index];
        var income = budget.CalculateTotalIncome();

        var taxationStrategy = TaxationStrategyFactory.Create(TaxationType);
        
        return income - taxationStrategy.Calculate(income);
    }
}
