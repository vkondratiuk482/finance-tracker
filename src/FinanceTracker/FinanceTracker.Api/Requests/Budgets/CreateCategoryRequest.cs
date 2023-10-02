using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Api.Requests.Budgets;

public sealed class CreateCategoryRequest
{
    [Required] 
    public Guid BudgetId { get; set; }

    [Required] 
    public string Name { get; set; }
}
