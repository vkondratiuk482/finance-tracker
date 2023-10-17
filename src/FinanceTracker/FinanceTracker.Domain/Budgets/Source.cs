namespace FinanceTracker.Domain.Budgets;

public class Source
{
    public Guid Id { get; init; }

    public int Amount { get; private set; }
    
    public Guid CurrencyId { get; private set; }

    public Guid CategoryId { get; private set; }

    public SourceTypes Type { get; private set; }

    public SourceFrequencies Frequency { get; private set; }

    public string Description { get; private set; }
    
    public Guid? PiggyBankId { get; set; }

    public DateTime CreatedAt { get; private set; }

    public Source(
        int amount,
        Guid currencyId,
        SourceTypes type,
        SourceFrequencies frequency,
        string description,
        Guid categoryId,
        Guid? piggyBankId = null,
        DateTime? createdAt = null)
    {
        Id = Guid.NewGuid();
        Type = type;
        Amount = amount;
        Frequency = frequency;
        CurrencyId = currencyId;
        CategoryId = categoryId;
        Description = description;
        PiggyBankId = piggyBankId;
        CreatedAt = createdAt ?? DateTime.Now;
    }

    private Source()
    {
    }
}
