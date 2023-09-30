using MediatR;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Modules.Customers.Commands.UpdateCustomerTaxationType;

public sealed class UpdateCustomerTaxationTypeHandler : IRequestHandler<UpdateCustomerTaxationTypeCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerTaxationTypeHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(UpdateCustomerTaxationTypeCommand command, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(command.Id);

        customer.UpdateTaxationType(command.TaxationType);

        await _customerRepository.SaveChanges();
    }
}
