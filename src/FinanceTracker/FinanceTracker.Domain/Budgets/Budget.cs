using FinanceTracker.Domain.Common;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Domain.Budgets;

public class Budget : AggregateRoot<BudgetId, Guid>
{
    public CustomerId CustomerId { get; private set; }

    private int _payday;

    public int Payday
    {
        get => _payday;

        private set
        {
            if (value < 1 || value > 28)
            {
                throw new ArgumentOutOfRangeException("Payday has to be in range from 1 to 28");
            }
        }
    }

    private readonly List<Category> _categories;

    public IReadOnlyList<Category> Categories => _categories.AsReadOnly();

    public Budget(CustomerId customerId, int payday = 1) : base(new BudgetId(Guid.NewGuid()))
    {
        Id = new BudgetId(Guid.NewGuid());
        Payday = payday;
        CustomerId = customerId;
        _categories = new List<Category>();
    }

    private Budget()
    {
    }

    public void AddCategory(Category category)
    {
        _categories.Add(category);
    }

    public void RemoveCategory(Category category)
    {
        _categories.Remove(category);
    }

    public void UpdatePayday(int payday)
    {
        Payday = payday;
    }

    public int CalculateTotalIncome()
    {
        return _categories.Sum(category => category.CalculateTotalIncome());
    }
}
