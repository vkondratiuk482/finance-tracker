using FinanceTracker.Domain.Common;

namespace FinanceTracker.Domain.Budgets;

public record BudgetId(Guid Value) : TypedId(Value);
