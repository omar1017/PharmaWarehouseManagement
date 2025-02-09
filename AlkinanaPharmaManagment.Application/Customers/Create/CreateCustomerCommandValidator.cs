using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Customers.Create
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.Customer.name).NotEmpty();
            RuleFor(c => c.Customer.address).NotEmpty();
            RuleFor(c => c.Customer.pharma).NotEmpty();
        }
    }
}
