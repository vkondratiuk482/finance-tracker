using FinanceTracker.Domain.Budgets;
using FinanceTracker.Domain.Customers;

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

        var source = new Source(10000, SourceTypes.Income, SourceFrequencies.Monthly, "Weekly payment", category.Id);

        category.AddSource(source);

        Console.WriteLine($"Hey {customer.Email.Value}, your net is {customer.CalculateTotalNet(0)}");
        
        customer.UpdateTaxationType(TaxationTypes.Zero);
        
        Console.WriteLine($"Hey {customer.Email.Value}, your net is {customer.CalculateTotalNet(0)}");
    }
}
