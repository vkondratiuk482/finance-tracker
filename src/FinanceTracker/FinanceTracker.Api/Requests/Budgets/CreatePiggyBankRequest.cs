using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Api.Requests.Budgets;

public sealed class CreatePiggyBankRequest
{
    [Required] 
    public Guid BudgetId { get; set; }

    [Required] 
    public string Name { get; set; }
    
    [Required] 
    public int ExpectedAmount { get; set; }
    
    [Required] 
    public DateTime UpTo { get; set; }
}
