using AlkinanaPharmaManagment.Domain.Entities.Customers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Infrastructure.Customers
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);

            builder.Property(c => c.CustomerId)
                   .HasConversion(
                       id => id.Value, 
                       value => new CustomerId(value)
                   )
                   .HasColumnName("CustomerId");

            builder.OwnsOne(c => c.customerName, name =>
            {
                name.Property(n => n.Value).HasColumnName("CustomerName");
            });

            builder.OwnsOne(c => c.pharma, pharma =>
            {
                pharma.Property(p => p.Value).HasColumnName("Pharma");
            });

            builder.OwnsOne(c => c.address, address =>
            {
                address.Property(a => a.Value).HasColumnName("Address");
            });

            builder.OwnsOne(c => c.Phone, phone => phone.Property(p => p.Value).HasColumnName("PhoneNumber"));
        }
    }
}
