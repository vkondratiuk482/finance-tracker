namespace FinanceTracker.Domain.Budgets;

public class Category
{
    public CategoryId Id { get; init; }

    public string Name { get; private set; }

    public BudgetId BudgetId { get; private set; }

    private readonly List<Source> _sources;

    public IReadOnlyList<Source> Sources => _sources.AsReadOnly();

    public Category(string name, BudgetId budgetId)
    {
        Id = new CategoryId(Guid.NewGuid());
        Name = name;
        BudgetId = budgetId;
        _sources = new List<Source>();
    }

    public void AddSource(Source source)
    {
        _sources.Add(source);
    }

    public void RemoveSource(Source source)
    {
        _sources.Remove(source);
    }

    public int CalculateTotalIncome()
    {
        return _sources
            .Where(source => source.Type == SourceTypes.Income)
            .Sum(source => source.Amount);
    }
}
