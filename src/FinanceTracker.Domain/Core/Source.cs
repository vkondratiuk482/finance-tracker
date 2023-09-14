using FinanceTracker.Domain.Core.Enums;

namespace FinanceTracker.Domain.Core;

public class Source 
{
    public Guid Id { get; private set; }
    
    public int Amount { get; private set; }
    
    public Guid CategoryId { get; private set; }
    
    public SourceTypes Type { get; private set; }
    
    public string Description { get; private set; }

    public Source(int amount, string description, SourceTypes type, Guid categoryId)
    {
        Type = type;
        Amount = amount;
        CategoryId = categoryId;
        Description = description;
    }
}
