using FinanceTracker.Domain.Budgets;
using MediatR;

namespace FinanceTracker.Application.Modules.Budgets.Queries.GetCurrencies;

public class GetCurrenciesQuery : IRequest<List<Currency>>
{
}
