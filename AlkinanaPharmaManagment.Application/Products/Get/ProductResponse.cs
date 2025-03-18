using AlkinanaPharmaManagment.Domain.Entities.Images;
using AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject;
using AlkinanaPharmaManagment.Domain.Entities.Warnings;
using AlkinanaPharmaManagment.Domain.ValueObject;

namespace AlkinanaPharmaManagment.Application.Products.Get
{
    public class ProductResponse
    {
        public ProductId ProductId { get; set; }
        public string ProductName { get; set; }
        public string? SName { get; set; }
        public Image ProductImage { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double? PublicPrice { get; set; }
        public string Supplier { get; set; }
        public bool? IsActive { get; set; }
        public string? Notes { get; set; }
        public Warning? Warning { get; set; }
        public int? Quantity { get; set; } = 0;
    }
}