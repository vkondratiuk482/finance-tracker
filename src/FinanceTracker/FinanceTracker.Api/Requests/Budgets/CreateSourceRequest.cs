using FinanceTracker.Domain.Budgets;

namespace FinanceTracker.Api.Requests.Budgets;

public class CreateSourceRequest
{
    public int Amount { get; set; }
    
    public SourceTypes Type { get; set; }
    
    public SourceFrequencies Frequency { get; set; }
    
    public string Description { get; set; }
    
    public Guid CategoryId { get; set; }
}
