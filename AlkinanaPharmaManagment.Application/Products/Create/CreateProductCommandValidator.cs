using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Create
{
    public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Product.name).NotNull();
            RuleFor(c => c.Product.description).NotNull();
            RuleFor(c => c.Product.price).NotNull();
            RuleFor(c => c.Product.image).NotNull();
            RuleFor(c => c.Product.supplier).NotNull();
            RuleFor(c => c.Product.companyName).NotNull();
        }
    }
}
