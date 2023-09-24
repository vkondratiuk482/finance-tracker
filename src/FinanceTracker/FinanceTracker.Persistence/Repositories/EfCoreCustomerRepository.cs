using FinanceTracker.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Persistence.Repositories;

public class EfCoreCustomerRepository : ICustomerRepository
{
    private readonly ApplicationContext _applicationContext;

    public EfCoreCustomerRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Customer?> GetById(Guid id)
    {
        return await _applicationContext.Customers
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(Customer customer)
    {
        await _applicationContext.AddAsync(customer);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task SaveChanges()
    {
        await _applicationContext.SaveChangesAsync();
    }
}
