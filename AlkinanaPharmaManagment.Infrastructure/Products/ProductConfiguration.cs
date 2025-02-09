using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Suppliers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Infrastructure.Products
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.ProductId);

            builder.Property(c => c.ProductId)
                   .HasConversion(
                       id => id.Value, 
                       value => new Domain.ValueObject.ProductId(value) 
                   )
                   .HasColumnName("ProductId");

            builder.OwnsOne(c => c.name, name =>
            {
                name.Property(n => n.Value).HasColumnName("ProductName");
            });

            builder.OwnsOne(c => c.supplier, pharma =>
            {
                pharma.Property(p => p.Value).HasColumnName("Supplier");
            });

            builder.OwnsOne(c => c.image, image =>
            {
                image.Property(a => a.Value).HasColumnName("Image");
            });

            builder.OwnsOne(c => c.companyName, company =>
            {
                company.Property(a => a.Value).HasColumnName("CompanyName");
            });

            builder.OwnsOne(c => c.description, desc =>
            {
                desc.Property(a => a.Value).HasColumnName("Description");
            });

            builder.OwnsOne(c => c.price, price =>
            {
                price.Property(a => a.Value).HasColumnName("Price");
            });

            builder.HasOne<Supplier>()
                .WithMany()
                .HasForeignKey(p => p.SupplierId);
           
        }
    }
}
