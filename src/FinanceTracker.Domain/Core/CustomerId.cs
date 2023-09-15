namespace FinanceTracker.Domain.Core;

public record CustomerId(Guid Value) : TypedId(Value);
