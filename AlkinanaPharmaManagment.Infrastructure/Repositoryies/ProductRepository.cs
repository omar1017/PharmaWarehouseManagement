using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Domain.ValueObject;
using AlkinanaPharmaManagment.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Infrastructure.Repositoryies
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Product product)
        {
            await context.Products.AddAsync(product);
        }

        public async Task DeleteAsync(ProductId productId)
        {
            var product = await GetAsync(productId);
             context.Products.Remove(product);
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(ProductId productId)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<List<Product>> GetProductsByCompany(string companyName)
        {
            return await context.Products.Where(p => p.companyName == companyName).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByName(string productName)
        {
            return await context.Products.Where(p => p.name == productName).ToListAsync();
        }

        public async Task<List<Product>> GetProductsBySupplier(string supplierName)
        {
            return await context.Products.Where(p => p.supplier == supplierName).ToListAsync();
        }

        public async Task SaveChangeAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            context.Update(product);
        }
    }
}
