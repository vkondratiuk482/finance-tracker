using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Api.Requests.Customer;
using FinanceTracker.Api.Responses.Common;
using FinanceTracker.Api.Responses.Customer;
using FinanceTracker.Application.Modules.Customers.Commands.Create;
using FinanceTracker.Application.Modules.Customers.Commands.CalculateBalance;
using FinanceTracker.Application.Modules.Customers.Commands.UpdateTaxationType;

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

    [HttpGet]
    [Route("balance")]
    [ProducesResponseType(typeof(CustomerBalanceResponse), StatusCodes.Status200OK)]
    public async Task<CustomerBalanceResponse> CalculateBalance([FromQuery] Guid id, [FromQuery] Guid budgetId)
    {
        var balance = await _mediator.Send(new CalculateCustomerBalanceCommand()
        {
            CustomerId = id,
            BudgetId = budgetId,
        });

        return new CustomerBalanceResponse
        {
            Netto = balance.Netto,
            Brutto = balance.Brutto,
            MoneyLeft = balance.MoneyLeft,
        };
    }

    [HttpPost]
    [ProducesResponseType(typeof(StatusResponse), StatusCodes.Status201Created)]
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
