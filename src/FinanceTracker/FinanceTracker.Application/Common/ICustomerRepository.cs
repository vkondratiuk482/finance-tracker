using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Common;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
}
