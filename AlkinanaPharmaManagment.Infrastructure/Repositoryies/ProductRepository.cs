using AlkinanaPharmaManagment.Application.Products;
using AlkinanaPharmaManagment.Application.Products.Get;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Warnings;
using AlkinanaPharmaManagment.Domain.ValueObject;
using AlkinanaPharmaManagment.Infrastructure.Database;
using Google.Apis.Drive.v3.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
            var product = await GetProduct(productId);
             context.Products.Remove(product);
        }

        private async Task<Product> GetProduct(ProductId productId)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.ProductId == productId); 
        }

        public async Task<ProductListResponse> GetAllAsync(ProductSearchRequest request,ClaimsPrincipal user)
        {  
            var query = context.Products.AsQueryable();
            var isAdmin = false;
            if (user.FindFirst("uid")?.Value != null)
            {
                var userId = Guid.Parse(user.FindFirst("uid")?.Value);
                 isAdmin = user.FindFirst(ClaimTypes.Role)?.Value == "Administrator";
                if (!isAdmin)
                {
                    query = query.Where(p => p.CreatedBy == userId);

                }
                else
                {
                    if (!string.IsNullOrEmpty(request.Supplier))
                        query = query.Where(p => p.supplier.Value.Contains(request.Supplier));
                }
            }
            else
            {
                throw new Exception("UnAuthorized user.");
            }

            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(p => p.name.Value.Contains(request.Name));

            if (!string.IsNullOrEmpty(request.SName))
                query = query.Where(p => p.SName.Contains(request.SName));

            if(!string.IsNullOrEmpty(request.Company))
                query = query.Where(p => p.companyName.Value.Contains(request.Company));

            var totalCount = await query.CountAsync();

           List<ProductResponse> products = new List<ProductResponse>();

            query =  query.AsNoTracking().OrderByDescending(p =>
            p.CreatedAt)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(p => p.Image)
                .Include(p => p.Warning)
                .ThenInclude(w => w.Image);

            if (isAdmin)
                products = await  query.Select(p => new ProductResponse
                {
                    ProductId = p.ProductId,
                    ProductName = p.name,
                    SName = p.SName,
                    ProductImage = p.Image,
                    Supplier = p.supplier,
                    Description = p.description,
                    CompanyName = p.companyName,
                    Price = p.price,
                    PublicPrice = p.PublicPrice,
                    Quantity = p.Quantity,
                    IsActive = p.IsActive,
                    Notes = p.Notes,
                    Warning = p.Warning
                }).ToListAsync();
            else
            {
                products = await query.Select(p => new ProductResponse
                {
                    ProductId = p.ProductId,
                    ProductName = p.name,
                    SName = p.SName,
                    ProductImage = p.Image,
                    Supplier = p.supplier,
                    Description = p.description,
                    CompanyName = p.companyName,
                    Price = p.price,
                    IsActive = p.IsActive,
                    Notes = p.Notes,
                }).ToListAsync();
            }
            return new ProductListResponse
            {
                TotalCount = totalCount,
                Products = products,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }

        public async Task<ProductListResponse> GetProducts(ProductSearchRequest request)
        {
            var query = context.Products.AsQueryable();
            
            query = query.Where(p => p.IsActive);

            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(p => p.name.Value.Contains(request.Name));

            if (!string.IsNullOrEmpty(request.SName))
                query = query.Where(p => p.SName.Contains(request.SName));


            if (!string.IsNullOrEmpty(request.Company))
                query = query.Where(p => p.companyName.Value.Contains(request.Company));

            var totalCount = await query.CountAsync();

            List<ProductResponse> products = new List<ProductResponse>();

            query = query.AsNoTracking().OrderByDescending(p =>
            p.CreatedAt)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(p => p.Image)
                .Include(p => p.Warning)
            .ThenInclude(w => w.Image);
            
            products = await query.Select(p => new ProductResponse
            {
                ProductId = p.ProductId,
                ProductName = p.name,
                SName = p.SName,
                PublicPrice = p.PublicPrice,
                ProductImage = p.Image,
                Description = p.description,
                CompanyName = p.companyName,
                IsActive = p.IsActive,
                Notes = p.Notes,
                Warning = p.Warning
            }).ToListAsync();
            
            return new ProductListResponse
            {
                TotalCount = totalCount,
                Products = products,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }

        public async Task<ProductResponse> GetAsync(ProductId productId)
        {
           var p = await context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.ProductId == productId);

            return new ProductResponse
            {
                ProductId = p.ProductId,
                ProductName = p.name,
                ProductImage = p.Image,
                Supplier = p.supplier,
                Description = p.description,
                CompanyName = p.companyName,
                Price = p.price,
                IsActive = p.IsActive,
                Notes = p.Notes
            };
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

        public async Task<Product> GetFullProductById(ProductId productId)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task AddWarning(Warning warning)
        {
            await context.Warnings.AddAsync(warning);
        }

        public async Task<Warning> GetWarningById(Guid Id)
        {
           return  await context.Warnings.FirstOrDefaultAsync(w => w.Id == Id);
        }

        
    }
}
