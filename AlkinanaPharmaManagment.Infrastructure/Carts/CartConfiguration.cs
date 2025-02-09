using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Infrastructure.Carts
{
    internal class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.CartId);

            builder.Property(c => c.CartId).HasConversion(
                CartId => CartId.Value,
                value => new CartId(value));

            builder.HasMany(c => c.lineItems)
                .WithOne()
                .HasForeignKey(li => li.cartId);
            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(c => c.CustomerId);

            builder.Property(c => c.CustomerId)
                   .HasConversion(
                       id => id.Value, // تحويل إلى القيمة الأساسية عند الحفظ
                       value => new CustomerId(value) // تحويل إلى الكائن عند الاسترجاع
                   )
                   .HasColumnName("CustomerId");
        }
    }
}
