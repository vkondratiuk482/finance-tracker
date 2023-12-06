using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Api.Requests.Budgets;
using FinanceTracker.Api.Responses.Budgets;
using FinanceTracker.Application.Modules.Budgets.Commands.CreatePiggyBank;

namespace FinanceTracker.Api.Controllers;

[ApiController]
[Route("api/piggy-banks")]
public sealed class PiggyBankController
{
    private readonly IMediator _mediator;

    public PiggyBankController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreatePiggyBankResponse), StatusCodes.Status201Created)]
    public async Task<CreatePiggyBankResponse> Create([FromBody] CreatePiggyBankRequest request)
    {
        var id = await _mediator.Send(new CreatePiggyBankCommand
        {
            Name = request.Name,
            UpTo = request.UpTo,
            BudgetId = request.BudgetId,
            ExpectedAmount = request.ExpectedAmount,
        });

        return new CreatePiggyBankResponse
        {
            Id = id,
        };
    }
}
