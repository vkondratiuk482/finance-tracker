namespace FinanceTracker.Domain.Common;

public abstract class Entity<TId>
{
    public TId Id { get; protected init; }

    protected Entity(TId id)
    {
        Id = id;
    }

    protected Entity()
    {
    }
}
