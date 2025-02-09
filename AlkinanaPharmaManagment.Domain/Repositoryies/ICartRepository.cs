using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetAllAsync();
        Task<Cart> GetByIdAsync(CartId cartId);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(Cart cart);
        Task SaveChangeAsync();
    }
}
