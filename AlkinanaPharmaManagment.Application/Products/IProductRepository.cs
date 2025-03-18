using AlkinanaPharmaManagment.Application.Products.Get;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Warnings;
using AlkinanaPharmaManagment.Domain.ValueObject;
using System.Security.Claims;

namespace AlkinanaPharmaManagment.Application.Products
{
    public interface IProductRepository
    {
        Task<ProductListResponse> GetAllAsync(ProductSearchRequest request, ClaimsPrincipal user);
        Task<ProductListResponse> GetProducts(ProductSearchRequest request);
        Task<ProductResponse> GetAsync(ProductId productId);
        Task AddAsync(Product product);
        Task<Product> GetFullProductById(ProductId productId);
        Task UpdateAsync(Product product);
        Task DeleteAsync(ProductId productId);
        Task<List<Product>> GetProductsByCompany(string companyName);
        Task<List<Product>> GetProductsByName(string productName);
        Task<List<Product>> GetProductsBySupplier(string supplierName);
        Task AddWarning(Warning warning);
        Task<Warning> GetWarningById(Guid Id);
        Task SaveChangeAsync();
    }
}
