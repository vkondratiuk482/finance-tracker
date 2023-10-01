using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Domain.Budgets;

public class Budget
{
    public Guid Id { get; init; }

    public Guid CustomerId { get; private set; }

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

    public Budget(Guid customerId, int payday = 1)
    {
        Id = Guid.NewGuid();
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

    public int CalculateTotalOutcome()
    {
        return _categories.Sum(category => category.CalculateTotalOutcome());
    }
}
