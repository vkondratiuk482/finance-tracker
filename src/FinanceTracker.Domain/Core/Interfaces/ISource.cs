namespace FinanceTracker.Domain.Core.Interfaces;

public interface ISource
{
    public int Amount { get; }
    
    public string Description { get; }
}
