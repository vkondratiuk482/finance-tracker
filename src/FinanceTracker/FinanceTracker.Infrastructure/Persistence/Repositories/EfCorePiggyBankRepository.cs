using FinanceTracker.Domain.Budgets;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

public class EfCorePiggyBankRepository : IPiggyBankRepository
{
    private readonly ApplicationContext _applicationContext;

    public EfCorePiggyBankRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<PiggyBank?> GetById(Guid id)
    {
        return await _applicationContext.PiggyBanks
            .Where(piggyBank => piggyBank.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(PiggyBank piggyBank)
    {
        await _applicationContext.PiggyBanks.AddAsync(piggyBank);
        await _applicationContext.SaveChangesAsync();
    }
}
