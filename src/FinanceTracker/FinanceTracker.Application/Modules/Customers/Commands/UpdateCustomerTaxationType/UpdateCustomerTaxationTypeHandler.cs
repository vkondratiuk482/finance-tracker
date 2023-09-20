using FinanceTracker.Application.Common;
using FinanceTracker.Application.Modules.Customers.Commands.CreateCustomer;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Modules.Customers.Commands.UpdateCustomerTaxationType;

public class UpdateCustomerTaxationTypeHandler : IHandler<UpdateCustomerTaxationTypeCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerTaxationTypeHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(UpdateCustomerTaxationTypeCommand command)
    {
        var id = new CustomerId(Guid.Parse(command.Id));

        var customer = await _customerRepository.GetById(id);

        customer.UpdateTaxationType(command.TaxationType);

        await _customerRepository.SaveChanges();
    }
}
