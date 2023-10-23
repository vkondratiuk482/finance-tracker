using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Domain.Budgets;

public class Budget
{
    public Guid Id { get; init; }

    public Guid CustomerId { get; private set; }
    
    public Guid CurrencyId { get; private set; }

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

            _payday = value;
        }
    }

    private readonly List<Category> _categories;
    private readonly List<PiggyBank> _piggyBanks;

    public IReadOnlyList<Category> Categories => _categories.AsReadOnly();
    public IReadOnlyList<PiggyBank> PiggyBanks => _piggyBanks.AsReadOnly();

    public Budget(Guid customerId, Guid currencyId, int payday = 1)
    {
        Id = Guid.NewGuid();
        Payday = payday;
        CustomerId = customerId;
        CurrencyId = currencyId;
        _categories = new List<Category>();
        _piggyBanks = new List<PiggyBank>();
    }

    private Budget()
    {
    }

    public void UpdatePayday(int payday)
    {
        Payday = payday;
    }

    public void AddCategory(Category category)
    {
        _categories.Add(category);
    }

    public int CalculateTotalIncome()
    {
        return _categories.Sum(category => category.CalculateTotalIncome());
    }

    public int CalculateTotalOutcome()
    {
        return _categories.Sum(category => category.CalculateTotalOutcome());
    }

    public int CalculateTotalSavings()
    {
        return _piggyBanks.Sum(piggyBank => piggyBank.CollectedAmount);
    }

    public int CalculateMoneyLeft(Customer customer)
    {
        var outcome = CalculateTotalOutcome();

        return CalculateTotalNetto(customer) - outcome;
    }

    public int CalculateTotalNetto(Customer customer)
    {
        var income = CalculateTotalIncome();

        return income - customer.TaxationStrategy.Calculate(income);
    }

    public decimal CalculateAuthorizedDailyExpenses(Customer customer, DateTime? upTo)
    {
        var currentDate = DateTime.Now;

        upTo ??= new DateTime(currentDate.Year, currentDate.Month + 1, Payday);

        var moneyLeft = CalculateTotalNetto(customer) - CalculateTotalOutcome();

        var daysLeft = (int)((DateTime)upTo).Subtract(currentDate).TotalDays;

        return moneyLeft / daysLeft;
    }
}
