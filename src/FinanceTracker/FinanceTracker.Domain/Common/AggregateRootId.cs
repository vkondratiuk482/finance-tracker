namespace FinanceTracker.Domain.Common;

public abstract record AggregateRootId<TIdType>(TIdType Value);
