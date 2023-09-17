using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Domain.Budgets;

public class Budget
{
    public BudgetId Id { get; init; }

    public CustomerId CustomerId { get; private set; }

    private readonly List<Category> _categories;

    public IReadOnlyList<Category> Categories => _categories.AsReadOnly();

    public Budget(CustomerId customerId)
    {
        Id = new BudgetId(Guid.NewGuid());
        CustomerId = customerId;
        _categories = new List<Category>();
    }

    public void AddCategory(Category category)
    {
        _categories.Add(category);
    }

    public void RemoveCategory(Category category)
    {
        _categories.Remove(category);
    }

    public int CalculateTotalIncome()
    {
        return _categories.Sum(category => category.CalculateTotalIncome());
    }
}
