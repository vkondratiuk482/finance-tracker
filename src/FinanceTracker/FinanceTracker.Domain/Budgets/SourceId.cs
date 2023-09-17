using FinanceTracker.Domain.Common;

namespace FinanceTracker.Domain.Budgets;

public record SourceId(Guid Value) : TypedId(Value);
