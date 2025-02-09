using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Carts.DeleteItems
{
    internal sealed class DeleteItemsCommandValidator : AbstractValidator<DeleteItemsCommand>
    {
        public DeleteItemsCommandValidator()
        {
            RuleFor(c => c.cartId).NotNull();
            RuleFor(c => c.lineItemId).NotNull();
        }
    }
}
