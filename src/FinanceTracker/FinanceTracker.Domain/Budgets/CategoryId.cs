using FinanceTracker.Domain.Common;

namespace FinanceTracker.Domain.Budgets;

public record CategoryId(Guid Value) : TypedId(Value);
