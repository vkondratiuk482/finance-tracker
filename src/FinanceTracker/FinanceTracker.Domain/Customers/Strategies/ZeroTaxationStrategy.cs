namespace FinanceTracker.Domain.Customers.Strategies;

public class ZeroTaxationStrategy : ITaxationStrategy
{
    public int Calculate(int amount)
    {
        return 0;
    }
}
