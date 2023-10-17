using MediatR;
using FinanceTracker.Domain.Budgets;

namespace FinanceTracker.Application.Modules.Budgets.Commands.CreateSource;

public sealed class CreateSourceHandler : IRequestHandler<CreateSourceCommand, Guid>
{
    private readonly ISourceRepository _sourceRepository;

    public CreateSourceHandler(ISourceRepository sourceRepository)
    {
        _sourceRepository = sourceRepository;
    }

    public async Task<Guid> Handle(CreateSourceCommand command, CancellationToken cancellationToken)
    {
        var source = new Source(
            command.Amount,
            command.CurrencyId,
            command.Type,
            command.Frequency,
            command.Description,
            command.CategoryId);

        await _sourceRepository.AddAsync(source);

        return source.Id;
    }
}
