using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Api.Requests.Budgets;
using FinanceTracker.Api.Responses.Budgets;
using FinanceTracker.Application.Modules.Budgets.Commands.CreateCategory;
using FinanceTracker.Application.Modules.Budgets.Queries.GetCurrencies;

namespace FinanceTracker.Api.Controllers;

[ApiController]
[Route("api/currencies")]
public sealed class CurrencyController
{
    private readonly IMediator _mediator;

    public CurrencyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<CurrencyResponse>), StatusCodes.Status200OK)]
    public async Task<List<CurrencyResponse>> Get()
    {
        var currencies = await _mediator.Send(new GetCurrenciesQuery());

        var response = new List<CurrencyResponse>();

        foreach (var currency in currencies)
        {
            response.Add(new CurrencyResponse
            {
                Id = currency.Id,
                Iso4217Num= currency.Iso4217Num,
                Iso4217Code= currency.Iso4217Code,
            });
        }

        return response;
    }
}
