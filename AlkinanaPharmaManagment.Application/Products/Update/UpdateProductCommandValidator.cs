using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Update
{
    public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(c => c.Product.name).NotEmpty();
            RuleFor(c => c.Product.description).NotEmpty();
            RuleFor(c => c.Product.price).NotEmpty();
            RuleFor(c => c.Product.image).NotEmpty();
            RuleFor(c => c.Product.supplier).NotEmpty();
            RuleFor(c => c.Product.companyName).NotEmpty();
        }
    }
}
