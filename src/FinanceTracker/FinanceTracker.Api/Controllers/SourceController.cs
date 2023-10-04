using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Api.Requests.Budgets;
using FinanceTracker.Api.Responses.Budgets;
using FinanceTracker.Application.Modules.Budgets.Commands.CreateSource;

namespace FinanceTracker.Api.Controllers;

[ApiController]
[Route("api/source")]
public class SourceController
{
    private readonly IMediator _mediator;

    public SourceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateSourceResponse), StatusCodes.Status201Created)]
    public async Task<CreateSourceResponse> Create([FromBody] CreateSourceRequest request)
    {
        var id = await _mediator.Send(new CreateSourceCommand
        {
            Amount = request.Amount,
            Type = request.Type,
            Frequency = request.Frequency,
            CategoryId = request.CategoryId,
            Description = request.Description,
        });

        return new CreateSourceResponse()
        {
            Id = id,
        };
    }
}
