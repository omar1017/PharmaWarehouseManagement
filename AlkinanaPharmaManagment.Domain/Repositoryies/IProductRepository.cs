using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetAllAsync();
        Task<Product> GetAsync(ProductId productId);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(ProductId productId);
        Task<List<Product>> GetProductsByCompany(string companyName);
        Task<List<Product>> GetProductsByName(string productName);
        Task<List<Product>> GetProductsBySupplier(string supplierName);
        Task SaveChangeAsync();

    }
}
