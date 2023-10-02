using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Api.Requests.Budgets;

public sealed class CreateBudgetRequest
{
    [Required] 
    public Guid CustomerId { get; set; }

    [Required] 
    public int Payday { get; set; }
}
