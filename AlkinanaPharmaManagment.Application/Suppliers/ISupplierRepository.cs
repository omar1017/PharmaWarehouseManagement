using AlkinanaPharmaManagment.Application.Products;
using AlkinanaPharmaManagment.Application.Products.Get;
using AlkinanaPharmaManagment.Domain.Entities.Suppliers;
using AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Suppliers
{
    public interface ISupplierRepository
    {
        Task<SupplierListResponse> GetAll(SupplierSearchRequest request);
        Task<Supplier> GetSupplierByUserId(string userId);
        Task AddSupplier(Supplier supplier);
        Task<Supplier> GetAsync(SupplierId supplierId);
        Task SaveChangeAsync();
    }
}
