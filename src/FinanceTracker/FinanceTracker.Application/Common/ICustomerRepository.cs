using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Common;

public interface ICustomerRepository
{
    Task<Customer> GetById(CustomerId id);
    
    Task AddAsync(Customer customer);
    
    Task SaveChanges();
}
