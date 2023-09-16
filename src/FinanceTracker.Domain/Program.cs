using FinanceTracker.Domain.Core;
using FinanceTracker.Domain.Core.Enums;
using FinanceTracker.Domain.Core.ValueObjects;

namespace FinanceTracker.Domain;

internal static class Program
{
    public static void Main(string[] args)
    {
        var customer = new Customer(TaxationTypes.Fop3, new Email("hello@kse.org.ua"));
        var budget = new Budget(customer.Id);

        customer.AddBudget(budget);

        var category = new Category("Job", budget.Id);

        budget.AddCategory(category);

        var source = new Source(10000, "Weekly payment", SourceTypes.Income, category.Id);

        category.AddSource(source);

        Console.WriteLine($"Hey {customer.Email.Value}, your net is {customer.CalculateTotalNet(0)}");
        
        customer.UpdateTaxationStrategy(TaxationTypes.Zero);
        
        Console.WriteLine($"Hey {customer.Email.Value}, your net is {customer.CalculateTotalNet(0)}");
    }
}
