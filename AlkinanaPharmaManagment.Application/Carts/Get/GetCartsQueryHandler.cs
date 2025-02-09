using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Carts.Get
{
    internal sealed class GetCartsQueryHandler(ICartRepository cartRepository,
        ICustomerRepository customerRepository)
        : IQueryHandler<GetCartsQuery, List<CartResponse>>
    {
        public async Task<List<CartResponse>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            var carts =  cartRepository.GetAllAsync().Result.Select(c => new CartResponse
            {
                CartId = c.CartId,
                Customer =  customerRepository.GetAsync(c.CustomerId).Result,
                LineItems = c.lineItems
            }).ToList() ;

            

            return carts;
        }
    }
}
