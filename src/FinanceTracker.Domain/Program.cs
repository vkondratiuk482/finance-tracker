using FinanceTracker.Domain.Core;
using FinanceTracker.Domain.Core.Enums;
using FinanceTracker.Domain.Core.ValueObjects;

namespace FinanceTracker.Domain;

internal static class Program
{
    public static void Main(string[] args)
    {
        var customer = new Customer(TaxationTypes.Fop3, new Email("hello@kse.org.ua"));
        
        Console.WriteLine("Hello World!!");
    }
}
