using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Carts.Get;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Carts.GetById
{
    internal sealed class GetCartByIdQueryHandler(ICartRepository cartRepository,
        ICustomerRepository customerRepository) : IQueryHandler<GetCartByIdQuery, Cart>
    {
        public async Task<Cart> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await cartRepository.GetByIdAsync(request.CartId);

            if (cart is null)
            {
                
            }

           

            return cart;
        }
    }
}
