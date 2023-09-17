namespace FinanceTracker.Domain.Customers.Strategies;

public static class TaxationStrategyFactory
{
    public static ITaxationStrategy Create(TaxationTypes type)
    {
        ITaxationStrategy strategy = type switch
        {
            TaxationTypes.Zero => new ZeroTaxationStrategy(),
            TaxationTypes.Fop3 => new Fop3TaxationStrategy()
        };

        return strategy;
    }
}
