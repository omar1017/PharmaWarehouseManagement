using AlkinanaPharmaManagment.Domain.Entities.Customers;
using AlkinanaPharmaManagment.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Carts.Create
{
    public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
    {
        private readonly ICustomerRepository customerRepository;

        public CreateCartCommandValidator(ICustomerRepository customerRepository)
        {
            RuleFor(c=>c.cartRequest.CustomerId).NotNull()
                ;
            RuleFor(c => c.cartRequest.LineItems).NotNull();
            this.customerRepository = customerRepository;
        }

        private async Task<bool> CustomerIsExists(CustomerId id, CancellationToken token)
        {
            return await customerRepository.IsCustomerExists(id);
        }
    }
}
