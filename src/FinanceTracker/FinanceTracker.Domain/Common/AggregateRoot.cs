namespace FinanceTracker.Domain.Common;

public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
    where TId : AggregateRootId<TIdType>
{
    // Have no idea how it works
    public new AggregateRootId<TIdType> Id { get; protected init; }

    protected AggregateRoot(TId id) : base(id)
    {
        Id = id;
    }
}
