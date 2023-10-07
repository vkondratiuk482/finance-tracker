namespace FinanceTracker.Domain.Budgets;

public class Category
{
    public Guid Id { get; init; }

    public string Name { get; private set; }

    public Guid BudgetId { get; private set; }

    private readonly List<Source> _sources;

    public IReadOnlyList<Source> Sources => _sources.AsReadOnly();

    public Category(string name, Guid budgetId)
    {
        Id = Guid.NewGuid();
        Name = name;
        BudgetId = budgetId;
        _sources = new List<Source>();
    }

    private Category()
    {
    }

    public int CalculateTotalIncome()
    {
        return _sources
            .Where(source => source.Type == SourceTypes.Income)
            .Sum(source => source.Amount);
    }

    public int CalculateTotalOutcome()
    {
        return _sources
            .Where(source => source.Type == SourceTypes.Outcome)
            .Sum(source => source.Amount);
    }
}
