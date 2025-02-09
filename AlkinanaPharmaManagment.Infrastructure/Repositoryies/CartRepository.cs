using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AlkinanaPharmaManagment.Infrastructure.Repositoryies;

internal class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext context;

    public CartRepository(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task AddAsync(Cart cart)
    {
        await context.Carts.AddAsync(cart);
    }

    public async Task DeleteAsync(Cart cart)
    {
         context.Carts.Remove(cart);
    }

    public async Task<List<Cart>> GetAllAsync()
    {
        return await context.Carts.ToListAsync();
    }

    public async Task<Cart> GetByIdAsync(CartId cartId)
    {
        return await context.Carts.FirstOrDefaultAsync(c => c.CartId == cartId);
    }

    public async Task SaveChangeAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cart cart)
    {
         context.Update(cart);
    }
}
