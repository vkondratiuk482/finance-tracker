using FinanceTracker.Domain.Core.Enums;

namespace FinanceTracker.Domain.Core;

public class Source
{
    public SourceId Id { get; init; }

    public int Amount { get; private set; }

    public CategoryId CategoryId { get; private set; }

    public SourceTypes Type { get; private set; }

    public string Description { get; private set; }

    public Source(int amount, string description, SourceTypes type, CategoryId categoryId)
    {
        Id = new SourceId(Guid.NewGuid());
        Type = type;
        Amount = amount;
        CategoryId = categoryId;
        Description = description;
    }
}
