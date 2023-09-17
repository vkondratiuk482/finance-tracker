namespace FinanceTracker.Domain.Customers.Strategies;

public class Fop3TaxationStrategy : ITaxationStrategy
{
    private const int FixedTax = 1474;

    public int Calculate(int amount)
    {
        return (amount * 5 / 100) + FixedTax;
    }
}
