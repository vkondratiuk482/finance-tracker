using FinanceTracker.Domain.Core;

namespace FinanceTracker.Application.Common;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
}
