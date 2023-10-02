using System.ComponentModel.DataAnnotations;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Api.Requests.Customers;

public sealed class CreateCustomerRequest
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public TaxationTypes TaxationType { get; set; }
}
