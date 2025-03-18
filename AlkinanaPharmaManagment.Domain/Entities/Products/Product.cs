
using AlkinanaPharmaManagment.Domain.Entities.Images;
using AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject;
using AlkinanaPharmaManagment.Domain.Entities.Suppliers;
using AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject;
using AlkinanaPharmaManagment.Domain.Entities.Warnings;
using AlkinanaPharmaManagment.Domain.ValueObject;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;

namespace AlkinanaPharmaManagment.Domain.Entities
{
    public class Product : AggregateRoot
    {
        public ProductId ProductId { get; set; }
        public ProductName name {get;  set;}
        public string? SName { get; set;}
        public CompanyName companyName {get;  set;}
        public Description description {get;  set;}
        public Price price {get;  set;}
        public int? Quantity {get; set;}
        public double? PublicPrice {get; set;}
        public Products.ValueObject.Supplier supplier {get;  set;}
        public Suppliers.Supplier? Supplier {get; set;}
        public bool IsActive {get;  set;}
        public string? Notes {get;  set;}
        public Guid ImageId {get;  set;}
        public Image Image {get;  set;}
        public Warning? Warning {get; set;}


        public static Product CreateProduct(ProductName productName,
            Guid imageId,
            CompanyName companyName,
            Description description,
            Price price,
            Products.ValueObject.Supplier supplierName,
            Suppliers.Supplier? supplier,
            bool isActive,
            string? notes)
        {
            var product = new Product(new ProductId(Guid.NewGuid()),productName, imageId, companyName, description, price, supplierName,supplier,isActive,notes);

            return product;
        }
        public static Product CreateProductForUpdate(
            ProductId productId,
            ProductName productName,
           Guid imageId,
           CompanyName companyName,
           Description description,
           Price price,
           Products.ValueObject.Supplier supplierName,
           Suppliers.Supplier? supplier,
           bool isActive,
           string? notes)
        {
            var product = new Product(productId, productName, imageId, companyName, description, price, supplierName,supplier,isActive,notes);

            return product;
        }
        public Product()
        {
            
        }

        internal Product(
               ProductId productId,
               ProductName productName,
               Guid imageId,
               CompanyName companyName,
               Description description,
               Price price,
               Products.ValueObject.Supplier supplierName,
               Entities.Suppliers.Supplier? supplier,
               bool isActive,
               string? notes
            )
        {
            this.ProductId = productId;
            this.price = price;
            this.name = productName;
            this.ImageId = imageId;
            this.companyName = companyName;
            this.description = description;
            this.supplier = supplierName;
            this.Supplier = supplier;
            this.IsActive = isActive;
            this.Notes = notes;
        }
    }
}
