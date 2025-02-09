using AlkinanaPharmaManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Infrastructure.Carts
{
    internal class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder.HasKey(li => li.lineItemId);

            builder.Property(li => li.lineItemId).HasConversion(
                    linItemId => linItemId.Value,
                    value => new LineItemId(value));

            builder.Property(li => li.price).HasConversion(price => price.Value, value => new Domain.Entities.Products.ValueObject.Price(value));

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(li => li.productId);

            builder.Property(li => li.productId).HasConversion(productId => productId.Value, value => new Domain.ValueObject.ProductId(value));
        }
    }
}
