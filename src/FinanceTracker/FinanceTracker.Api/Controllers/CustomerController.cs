using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Api.Requests.Customers;
using FinanceTracker.Api.Responses.Common;
using FinanceTracker.Api.Responses.Customers;
using FinanceTracker.Application.Modules.Customers.Commands.Create;
using FinanceTracker.Application.Modules.Customers.Commands.UpdateTaxationType;

namespace FinanceTracker.Api.Controllers;

[ApiController]
[Route("api/customers")]
public sealed class CustomerController : Controller
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status201Created)]
    public async Task<CreateCustomerResponse> Create([FromBody] CreateCustomerRequest request)
    {
        var id = await _mediator.Send(new CreateCustomerCommand
        {
            Email = request.Email,
            TaxationType = request.TaxationType,
        });

        return new CreateCustomerResponse
        {
            Id = id,
        };
    }

    [HttpPatch]
    [Route("taxation-type")]
    [ProducesResponseType(typeof(StatusResponse), StatusCodes.Status200OK)]
    public async Task<StatusResponse> UpdateTaxationType([FromQuery] Guid id,
        [FromBody] UpdateCustomerTaxationTypeRequest request)
    {
        await _mediator.Send(new UpdateCustomerTaxationTypeCommand()
        {
            Id = id,
            TaxationType = request.TaxationType,
        });

        return new StatusResponse
        {
            Success = true,
        };
    }
}
