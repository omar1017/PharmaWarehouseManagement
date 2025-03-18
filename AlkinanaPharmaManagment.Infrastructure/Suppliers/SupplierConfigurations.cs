using AlkinanaPharmaManagment.Domain.Entities.Suppliers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlkinanaPharmaManagment.Infrastructure.Suppliers
{
    internal class SupplierConfigurations : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.SupplierId);

            builder.Property(s => s.SupplierId)
                   .HasConversion(
                       id => id.value,
                       value => new(value)
                   );

            builder.OwnsOne(s => s.SupplierAddress, Address => Address.Property(a => a.Value).HasColumnName("Address"));
            builder.OwnsOne(s => s.SupplierEmail, Email => Email.Property(a => a.Value).HasColumnName("Email"));
            builder.OwnsOne(s => s.SupplierFirstName, FirstName => FirstName.Property(f => f.Value).HasColumnName("FirstName"));
            builder.OwnsOne(s => s.SupplierLastName, LastName => LastName.Property(l => l.Value).HasColumnName("LastName"));
            builder.OwnsOne(s => s.SupplierName, Name => Name.Property(n => n.Value).HasColumnName("Name"));
            builder.OwnsOne(s => s.UserId, UserId => UserId.Property(n => n.Value).HasColumnName("UserId"));


        }
    }
}
