namespace FinanceTracker.Domain.Budgets;

public class Source
{
    public SourceId Id { get; init; }

    public int Amount { get; private set; }

    public CategoryId CategoryId { get; private set; }

    public SourceTypes Type { get; private set; }
    
    public SourceFrequencies Frequency { get; private set; }

    public string Description { get; private set; }
    
    public DateTime CreatedAt { get; private set; }

    public Source(
        int amount, 
        SourceTypes type, 
        SourceFrequencies frequency,
        string description, 
        CategoryId categoryId, 
        DateTime? createdAt = null)
    {
        Id = new SourceId(Guid.NewGuid());
        Type = type;
        Amount = amount;
        Frequency = frequency;
        CategoryId = categoryId;
        Description = description;
        CreatedAt = createdAt ?? DateTime.Now;
    }
}
