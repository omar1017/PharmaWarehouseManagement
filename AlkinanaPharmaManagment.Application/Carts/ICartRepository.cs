using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlkinanaPharmaManagment.Application.Products;
using AlkinanaPharmaManagment.Application.Carts.Get;

namespace AlkinanaPharmaManagment.Application.Carts
{
    public interface ICartRepository
    {
        Task<CartListResponse> GetAllAsync(CartSearchRequest request);
        Task<Cart> GetByIdAsync(CartId cartId);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(Cart cart);
        Task SaveChangeAsync();
    }
}
