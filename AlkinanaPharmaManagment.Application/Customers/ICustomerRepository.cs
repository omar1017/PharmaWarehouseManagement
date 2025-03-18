using AlkinanaPharmaManagment.Application.Carts.Get;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Customers
{
    public interface ICustomerRepository
    {
        Task<IList<Customer>> GetAllAsync();
        Task<CustomerResponse> GetAsync(CustomerId customerId);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
        Task<bool> IsCustomerExists(CustomerId customerId);

        Task<List<Customer>> GetCustomersByCity(string city);
        Task<List<Customer>> GetCustomersByName(string Name);

        Task<List<Customer>> GetCustomersByPharma(string Pharma);

        Task SaveChangeAsync();
    }
}
