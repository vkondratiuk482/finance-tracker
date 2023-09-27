using FinanceTracker.Application.Common;
using FinanceTracker.Application.Modules.Customers.Commands.CreateCustomer;
using FinanceTracker.Domain.Customers;

namespace FinanceTracker.Application.Modules.Customers.Commands.UpdateCustomerTaxationType;

public class UpdateCustomerTaxationTypeHandler : IHandler<UpdateCustomerTaxationTypeCommand, Task>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerTaxationTypeHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(UpdateCustomerTaxationTypeCommand command)
    {
        var customer = await _customerRepository.GetById(command.Id);

        customer.UpdateTaxationType(command.TaxationType);

        await _customerRepository.SaveChanges();
    }
}
