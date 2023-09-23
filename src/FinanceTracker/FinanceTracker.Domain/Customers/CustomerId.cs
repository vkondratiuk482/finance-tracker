using FinanceTracker.Domain.Common;

namespace FinanceTracker.Domain.Customers;

public record CustomerId(Guid Value) : AggregateRootId<Guid>(Value);
