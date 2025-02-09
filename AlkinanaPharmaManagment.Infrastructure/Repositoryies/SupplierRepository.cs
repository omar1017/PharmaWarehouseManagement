using AlkinanaPharmaManagment.Domain.Entities.Suppliers;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Supplier> GetSupplierByUserId(string userId)
        {
            var id = Guid.Parse(userId);
            var entity =  await context.Suppliers.FirstOrDefaultAsync(s => s.UserId.Value == id);
            return entity;
        }
    }
}
