using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Api.Requests.Budgets;
using FinanceTracker.Api.Responses.Budgets;
using FinanceTracker.Application.Modules.Budgets.Commands.Create;

namespace FinanceTracker.Api.Controllers;

[ApiController]
[Route("api/budget")]
public class BudgetController
{
    private readonly IMediator _mediator;

    public BudgetController(IMediator mediator)
    {
        _mediator = mediator;
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
