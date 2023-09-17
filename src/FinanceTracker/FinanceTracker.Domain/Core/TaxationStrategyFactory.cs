using FinanceTracker.Domain.Core.Enums;

namespace FinanceTracker.Domain.Core;

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
