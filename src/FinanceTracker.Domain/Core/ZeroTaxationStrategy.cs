namespace FinanceTracker.Domain.Core;

public class ZeroTaxationStrategy : ITaxationStrategy
{
    public int Calculate(int amount)
    {
        return 0;
    }
}
