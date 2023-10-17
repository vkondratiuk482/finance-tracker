using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Api.Requests.Budgets;
using FinanceTracker.Api.Responses.Budgets;
using FinanceTracker.Application.Modules.Budgets.Commands.Create;
using FinanceTracker.Application.Modules.Budgets.Queries.CalculateStatistics;

namespace FinanceTracker.Api.Controllers;

[ApiController]
[Route("api/budget")]
public sealed class BudgetController
{
    private readonly IMediator _mediator;

    public BudgetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("statistics")]
    [ProducesResponseType(typeof(BudgetStatisticsResponse), StatusCodes.Status200OK)]
    public async Task<BudgetStatisticsResponse> CalculateBalance([FromQuery] Guid id,
        [FromQuery] Guid customerId,
        [FromQuery] DateTime? upTo = null)
    {
        var statistics = await _mediator.Send(new CalculateBudgetStatisticsQuery
        {
            UpTo = upTo,
            BudgetId = id,
            CustomerId = customerId,
        });

        return new BudgetStatisticsResponse
        {
            Netto = statistics.Netto,
            Brutto = statistics.Brutto,
            Savings = statistics.Savings,
            MoneyLeft = statistics.MoneyLeft,
            AuthorizedDailyExpenses = statistics.AuthorizedDailyExpenses,
        };
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateBudgetResponse), StatusCodes.Status201Created)]
    public async Task<CreateBudgetResponse> Create([FromBody] CreateBudgetRequest request)
    {
        var id = await _mediator.Send(new CreateBudgetCommand
        {
            Payday = request.Payday,
            CustomerId = request.CustomerId,
        });

        return new CreateBudgetResponse
        {
            Id = id,
        };
    }
}
