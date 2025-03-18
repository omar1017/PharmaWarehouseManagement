using AlkinanaPharmaManagment.Application.Customers;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using FluentValidation;

namespace AlkinanaPharmaManagment.Application.Carts.Create
{
    public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
    {
        private readonly ICustomerRepository customerRepository;

        public CreateCartCommandValidator(ICustomerRepository customerRepository)
        {
               
            this.customerRepository = customerRepository;
        }

        private async Task<bool> CustomerIsExists(CustomerId id, CancellationToken token)
        {
            return await customerRepository.IsCustomerExists(id);
        }
    }
}
