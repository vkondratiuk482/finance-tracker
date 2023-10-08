using FinanceTracker.Domain.Budgets;
using FinanceTracker.Domain.Customers.Strategies;

namespace FinanceTracker.Domain.Customers;

public class Customer
{
    public Guid Id { get; init; }

    private readonly List<Budget> _budgets;

    /**
     * .AsReadOnly() covers the following scenario:
     * (customer.Budgets as List<Budget>).Clear()
     */
    public IReadOnlyList<Budget> Budgets => _budgets.AsReadOnly();

    public Email Email { get; private set; }

    public TaxationTypes TaxationType { get; private set; }

    public ITaxationStrategy TaxationStrategy => TaxationStrategyFactory.Create(TaxationType);

    public Customer(TaxationTypes taxationType, Email email)
    {
        Id = Guid.NewGuid();
        Email = email;
        TaxationType = taxationType;
        _budgets = new List<Budget>();
    }

    private Customer()
    {
    }

    public void UpdateTaxationType(TaxationTypes taxationType)
    {
        TaxationType = taxationType;
    }
}
