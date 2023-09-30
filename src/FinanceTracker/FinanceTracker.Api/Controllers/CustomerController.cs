using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Api.Requests.Customer;
using FinanceTracker.Api.Responses.Common;
using FinanceTracker.Application.Modules.Customers.Commands.CreateCustomer;
using FinanceTracker.Application.Modules.Customers.Commands.UpdateCustomerTaxationType;

namespace FinanceTracker.Api.Controllers;

[ApiController]
[Route("api/customer")]
public sealed class CustomerController : Controller
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<StatusResponse> Create([FromBody] CreateCustomerRequest request)
    {
        await _mediator.Send(new CreateCustomerCommand
        {
            Email = request.Email,
            TaxationType = request.TaxationType,
        });

        return new StatusResponse
        {
            Success = true,
        };
    }

    [HttpPatch]
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
