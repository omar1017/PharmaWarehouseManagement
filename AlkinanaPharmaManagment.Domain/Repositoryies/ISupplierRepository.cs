using AlkinanaPharmaManagment.Domain.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Repositories
{
    public interface ISupplierRepository
    {
        Task<Supplier> GetSupplierByUserId(string userId);
        Task AddSupplier(Supplier supplier);
    }
}
