namespace FinanceTracker.Domain.Budgets;

public class PiggyBank
{
    public Guid Id { get; init; }

    public Guid BudgetId { get; private set; }

    public string Name { get; private set; }

    public int ExpectedAmount { get; private set; }

    public int CollectedAmount { get; private set; }

    public DateTime UpTo { get; private set; }

    private readonly string _categoryName = "Savings";

    private readonly List<Source> _sources;

    public IReadOnlyList<Source> Sources => _sources.AsReadOnly();

    public PiggyBank(Guid budgetId, string name, int expectedAmount, DateTime upTo)
    {
        Id = Guid.NewGuid();
        Name = name;
        UpTo = upTo;
        BudgetId = budgetId;
        CollectedAmount = 0;
        ExpectedAmount = expectedAmount;
        _sources = new List<Source>();
    }

    public void Fill(Budget budget, int amount)
    {
        var category = budget.Categories.FirstOrDefault(category => category.Name == _categoryName);

        if (category == null)
        {
            category = new Category(_categoryName, budget.Id);

            budget.AddCategory(category);
        }

        CollectedAmount += amount;

        var source = new Source(amount, SourceTypes.Outcome, SourceFrequencies.OneTime, Name, category.Id);

        category.AddSource(source);
    }

    public void Withdraw(Budget budget, int amount)
    {
        if (CollectedAmount == 0)
        {
            // there is nothing to withdraw 
        }

        if (amount > CollectedAmount)
        {
            // you can't withdraw more than you actually have on your savings account
        }

        var category = budget.Categories.First(category => category.Name == _categoryName);

        CollectedAmount -= amount;

        var source = new Source(amount, SourceTypes.Income, SourceFrequencies.OneTime, Name, category.Id);

        category.AddSource(source);
    }

    public void Break(Budget budget, Currency currency)
    {
        if (CollectedAmount == 0)
        {
            // there is nothing to withdraw 
        }

        var category = budget.Categories.First(category => category.Name == _categoryName);

        var source = new Source(CollectedAmount, SourceTypes.Income, SourceFrequencies.OneTime, Name,
            category.Id);

        CollectedAmount = 0;

        category.AddSource(source);
    }
}
