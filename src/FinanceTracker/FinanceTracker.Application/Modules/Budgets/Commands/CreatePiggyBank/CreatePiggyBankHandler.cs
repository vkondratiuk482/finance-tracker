using MediatR;
using FinanceTracker.Domain.Budgets;

namespace FinanceTracker.Application.Modules.Budgets.Commands.CreatePiggyBank;

public sealed class CreateCategoryHandler : IRequestHandler<CreatePiggyBankCommand, Guid>
{
    private readonly IPiggyBankRepository _piggyBankRepository;

    public CreateCategoryHandler(IPiggyBankRepository piggyBankRepository)
    {
        _piggyBankRepository = piggyBankRepository;
    }

    public async Task<Guid> Handle(CreatePiggyBankCommand command, CancellationToken cancellationToken)
    {
        var piggyBank = new PiggyBank(command.BudgetId, command.Name, command.ExpectedAmount, command.UpTo);

        await _piggyBankRepository.AddAsync(piggyBank);

        return piggyBank.Id;
    }
}
