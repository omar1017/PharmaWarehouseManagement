using AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Suppliers
{
    public class Supplier : AggregateRoot
    {
        public SupplierId Id { get; private set; }
        public UserId UserId { get; private set; }
        public SupplierName SupplierName { get; private set; }
        public SupplierFirstName SupplierFirstName { get; private set; }
        public SupplierLastName SupplierLastName { get; private set; }
        public SupplierEmail SupplierEmail { get; private set; }
        public SupplierAddress SupplierAddress { get; private set; }

        public static Supplier CreateSupplier(
            UserId userId,
            SupplierName supplierName,
            SupplierFirstName supplierFirstName,
            SupplierLastName supplierLastName,
            SupplierEmail supplierEmail,
            SupplierAddress supplierAddress)
        {
            var supplier = new Supplier(
                new SupplierId(Guid.NewGuid()),
                userId,
                supplierName,
                supplierFirstName,
                supplierLastName,
                supplierEmail,
                supplierAddress);
            return supplier;
        }

        public Supplier() { }

        internal Supplier(SupplierId id, UserId userId, SupplierName supplierName, SupplierFirstName supplierFirstName, SupplierLastName supplierLastName, SupplierEmail supplierEmail, SupplierAddress supplierAddress)
        {
            Id = id;
            UserId = userId;
            SupplierName = supplierName;
            SupplierFirstName = supplierFirstName;
            SupplierLastName = supplierLastName;
            SupplierEmail = supplierEmail;
            SupplierAddress = supplierAddress;
        }
    }
}
