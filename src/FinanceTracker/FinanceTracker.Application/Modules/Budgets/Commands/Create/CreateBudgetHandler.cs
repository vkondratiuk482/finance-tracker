using MediatR;
using FinanceTracker.Domain.Budgets;

namespace FinanceTracker.Application.Modules.Budgets.Commands.Create;

public sealed class CreateBudgetHandler : IRequestHandler<CreateBudgetCommand, Guid>
{
    private readonly IBudgetRepository _budgetRepository;

    public CreateBudgetHandler(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public async Task<Guid> Handle(CreateBudgetCommand command, CancellationToken cancellationToken)
    {
        var budget = new Budget(command.CustomerId, command.Payday);

        await _budgetRepository.AddAsync(budget);

        return budget.Id;
    }
}
