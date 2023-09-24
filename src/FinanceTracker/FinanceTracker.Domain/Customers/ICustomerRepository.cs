namespace FinanceTracker.Domain.Customers;

public interface ICustomerRepository
{
    Task<Customer?> GetById(Guid id);
    
    Task AddAsync(Customer customer);
    
    Task SaveChanges();
}
