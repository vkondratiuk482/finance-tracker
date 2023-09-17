namespace FinanceTracker.Domain.Customers.Strategies;

public interface ITaxationStrategy
{
    int Calculate(int amount);
}
