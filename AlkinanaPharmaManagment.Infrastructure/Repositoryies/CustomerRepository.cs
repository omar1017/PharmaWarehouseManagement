﻿using AlkinanaPharmaManagment.Application.Carts.Get;
using AlkinanaPharmaManagment.Application.Customers;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using AlkinanaPharmaManagment.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AlkinanaPharmaManagment.Infrastructure.Repositoryies
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext context;

        public CustomerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Customer customer)
        {
            await context.Customers.AddAsync(customer);
        }

        public async  Task DeleteAsync(Customer customer)
        {
            context.Customers.Remove(customer);
        }

        public async Task<IList<Customer>> GetAllAsync()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<CustomerResponse> GetAsync(CustomerId customerId)
        {
            var customer = await context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.CustomerId == customerId);

            return new CustomerResponse
            {
                Id = customer.CustomerId,
                Name = customer.customerName,
                PharmaName = customer.customerName,
                Address = customer.address,
                PhoneNumber = customer.Phone
            };
        }

        public async Task<List<Customer>> GetCustomersByCity(string city)
        {
            return await context.Customers.Where(c => c.address == city).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByName(string Name)
        {
            return await context.Customers.Where(c => c.customerName == Name).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByPharma(string Pharma)
        {
            return await context.Customers.Where(c => c.pharma == Pharma).ToListAsync();
        }

        public async Task<bool> IsCustomerExists(CustomerId customerId)
        {
            return await GetAsync(customerId) is not null;
        }

        public async Task SaveChangeAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            context.Customers.Update(customer);
        }
    }
}
