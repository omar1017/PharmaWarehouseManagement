using AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject;
using AlkinanaPharmaManagment.Domain.ValueObject;

namespace AlkinanaPharmaManagment.Application.Products.Get
{
    public class ProductResponse
    {
        public ProductId ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Supplier { get; set; }
    }
}