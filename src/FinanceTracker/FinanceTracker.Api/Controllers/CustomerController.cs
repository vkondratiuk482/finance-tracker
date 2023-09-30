using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Domain.Customers;
using FinanceTracker.Application.Modules.Customers.Commands.CreateCustomer;

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
    public async Task Create([FromQuery] string email, [FromQuery] string taxationType)
    {
        await _mediator.Send(new CreateCustomerCommand
        {
            Email = email,
            TaxationType = Enum.Parse<TaxationTypes>(taxationType)
        });
    }
}
