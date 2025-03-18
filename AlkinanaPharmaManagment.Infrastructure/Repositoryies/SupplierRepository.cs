using AlkinanaPharmaManagment.Application.Products;
using AlkinanaPharmaManagment.Application.Products.Get;
using AlkinanaPharmaManagment.Application.Suppliers;
using AlkinanaPharmaManagment.Domain.Entities.Suppliers;
using AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject;
using AlkinanaPharmaManagment.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AlkinanaPharmaManagment.Infrastructure.Repositoryies
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext context;

        public SupplierRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddSupplier(Supplier supplier)
        {
            await context.Suppliers.AddAsync(supplier);
        }

        public async Task<SupplierListResponse> GetAll(SupplierSearchRequest request)
        {
            var query = context.Suppliers.AsQueryable();

            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(p => p.SupplierName.Value.Contains(request.Name));

            if (!string.IsNullOrEmpty(request.Address))
                query = query.Where(p => p.SupplierAddress.Value.Contains(request.Address));

            var totalCount = await query.CountAsync();

            var suppliers = await query.AsNoTracking()
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new SupplierResponse
                {
                   Id = p.SupplierId,
                   Name = p.SupplierName,
                   Address = p.SupplierAddress,
                   FirstName = p.SupplierFirstName,
                   LastName = p.SupplierLastName,
                   Email = p.SupplierEmail,
                   IsActive = p.IsDeleted,
                }).ToListAsync();

            return new SupplierListResponse
            {
                TotalCount = totalCount,
                Suppliers = suppliers,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }

        public Task<Supplier> GetAsync(SupplierId supplierId)
        {
            return context.Suppliers.FirstOrDefaultAsync(s => s.SupplierId == supplierId);
        }

        public async Task<Supplier> GetSupplierByUserId(string userId)
        {
            var id = Guid.Parse(userId);
            var entity =  await context.Suppliers.FirstOrDefaultAsync(s => s.UserId.Value == id);
            return entity;
        }

        public async Task SaveChangeAsync()
        {
             context.SaveChanges();
        }
    }
}
