using MediatR;
using FinanceTracker.Domain.Budgets;

namespace FinanceTracker.Application.Modules.Budgets.Queries.GetCurrencies;

public sealed class
    GetCurrenciesHandler : IRequestHandler<GetCurrenciesQuery, List<Currency>>
{
    private readonly ICurrencyRepository _currencyRepository;

    public GetCurrenciesHandler(ICurrencyRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }

    public async Task<List<Currency>> Handle(GetCurrenciesQuery query,
        CancellationToken cancellationToken)
    {
        return await _currencyRepository.GetAsync();
    }
}
