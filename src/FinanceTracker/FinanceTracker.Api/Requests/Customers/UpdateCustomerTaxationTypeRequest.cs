using System.ComponentModel.DataAnnotations;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Api.Requests.Customers;

public sealed class UpdateCustomerTaxationTypeRequest
{
    [Required]
    public TaxationTypes TaxationType { get; set; }
}
