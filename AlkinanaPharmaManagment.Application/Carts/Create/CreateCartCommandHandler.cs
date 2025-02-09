using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Exceptions;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Carts.Events;
using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Carts.Create
{
    public sealed class CreateCartCommandHandler(ICartRepository cartRepository,
        ICustomerRepository customerRepository)
        : ICommandHandler<CreateCartCommand, CartId>
    {
       
        public async Task<CartId> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCartCommandValidator(customerRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var cart = Cart.Create(request.cartRequest.CustomerId);

            cart.AddItems(request.cartRequest.LineItems);

            cart.Raise(new CartCreatedEvent(cart.CartId));
            await cartRepository.AddAsync(cart);
            await cartRepository.SaveChangeAsync();

            return cart.CartId;
        }
    }
}
