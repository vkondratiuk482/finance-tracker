using FinanceTracker.Domain.Core.Enums;

namespace FinanceTracker.Domain.Core;

public class Customer
{
    public Guid Id { get; private set; }
    
    private readonly List<Budget> _budgets;
    
    private ITaxationStrategy TaxationStrategy { get; set; }

    public Customer(TaxationTypes taxationType)
    {
        Id = Guid.NewGuid();
        _budgets = new List<Budget>();
        TaxationStrategy = taxationType switch
        {
            TaxationTypes.Zero => new ZeroTaxationStrategy(),
            TaxationTypes.Fop3 => new Fop3TaxationStrategy()
        };
    }
}
