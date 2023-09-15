namespace FinanceTracker.Domain.Core;

public record BudgetId(Guid Value) : TypedId(Value);
