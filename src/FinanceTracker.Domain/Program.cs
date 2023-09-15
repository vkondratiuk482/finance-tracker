using FinanceTracker.Domain.Core;
using FinanceTracker.Domain.Core.Enums;

namespace FinanceTracker.Domain;

internal static class Program
{
    public static void Main(string[] args)
    {
        var customer = new Customer(TaxationTypes.Fop3, "hello@kse.org.ua");
        
        Console.WriteLine("Hello World!!");
    }
}
