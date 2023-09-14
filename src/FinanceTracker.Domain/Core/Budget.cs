namespace FinanceTracker.Domain.Core;

public class Budget
{
    public Guid Id { get; private set; }
    
    public Guid CustomerId { get; private set; }

    private readonly List<Category> _categories;
    
    public Budget(Guid customerId)
    {
        Id =  Guid.NewGuid();
        CustomerId = customerId;
        _categories = new List<Category>();
    }

    public int CalculateTotalIncome()
    {
        throw new NotImplementedException();
    }
}
