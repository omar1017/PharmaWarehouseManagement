using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Exceptions;
using AlkinanaPharmaManagment.Domain.Entities.Carts.Events;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Carts.Delete
{
    internal sealed class DeleteCartCommandHandler(ICartRepository cartRepository) : ICommandHandler<DeleteCartCommand,Unit>
    {
        public async Task<Unit> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await cartRepository.GetByIdAsync(request.cartId);

            if (cart is null) {
                throw new NotFoundException(nameof(cart),request.cartId);
            }

            await cartRepository.DeleteAsync(cart);

            //raise----
            cart.Raise(new CartDeletedEvent(cart));
            await cartRepository.SaveChangeAsync();

            return Unit.Value;

        }
    }
}
