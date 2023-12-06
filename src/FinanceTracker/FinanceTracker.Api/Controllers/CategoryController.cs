using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Api.Requests.Budgets;
using FinanceTracker.Api.Responses.Budgets;
using FinanceTracker.Application.Modules.Budgets.Commands.CreateCategory;

namespace FinanceTracker.Api.Controllers;

[ApiController]
[Route("api/categories")]
public sealed class CategoryController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateCategoryResponse), StatusCodes.Status201Created)]
    public async Task<CreateCategoryResponse> Create([FromBody] CreateCategoryRequest request)
    {
        var id = await _mediator.Send(new CreateCategoryCommand
        {
            Name = request.Name,
            BudgetId = request.BudgetId,
        });

        return new CreateCategoryResponse
        {
            Id = id,
        };
    }
}
