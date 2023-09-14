namespace FinanceTracker.Domain.Core;

public interface ITaxationStrategy
{
    int Calculate(int amount);
}
