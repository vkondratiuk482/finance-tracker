using FinanceTracker.Domain.Core.Enums;
using FinanceTracker.Domain.Core.ValueObjects;

namespace FinanceTracker.Domain.Core;

public class Customer
{
    public CustomerId Id { get; private set; }

    private List<Budget> _budgets;

    /**
     * .AsReadOnly() covers the following scenario:
     * (customer.Budgets as List<Budget>).Clear()
     */
    public IReadOnlyList<Budget> Budgets => _budgets.AsReadOnly();

    public Email Email { get; private set; }

    private ITaxationStrategy TaxationStrategy { get; set; }

    public Customer(TaxationTypes taxationType, Email email)
    {
        Email = email;
        Id = new CustomerId(Guid.NewGuid());
        _budgets = new List<Budget>();
        TaxationStrategy = taxationType switch
        {
            TaxationTypes.Zero => new ZeroTaxationStrategy(),
            TaxationTypes.Fop3 => new Fop3TaxationStrategy()
        };
    }

    public void AddBudget(Budget budget)
    {
        _budgets.Add(budget);
    }

    public void RemoveBudget(Budget budget)
    {
        _budgets.Remove(budget);
    }

    public int CalculateTotalIncome(int index)
    {
        var budget = _budgets[index];
        var income = budget.CalculateTotalIncome();

        return income - TaxationStrategy.Calculate(income);
    }
}
