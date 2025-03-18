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
        public SupplierId SupplierId { get;  set; }
        public UserId UserId { get;  set; }
        public SupplierName SupplierName { get;  set; }
        public SupplierFirstName SupplierFirstName { get;  set; }
        public SupplierLastName SupplierLastName { get;  set; }
        public SupplierEmail SupplierEmail { get;  set; }
        public SupplierAddress SupplierAddress { get;  set; }
        public List<Product> Products { get; set; }

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
            SupplierId = id;
            UserId = userId;
            SupplierName = supplierName;
            SupplierFirstName = supplierFirstName;
            SupplierLastName = supplierLastName;
            SupplierEmail = supplierEmail;
            SupplierAddress = supplierAddress;
        }
    }
}
