using AlkinanaPharmaManagment.Application.Products.Get;

namespace AlkinanaPharmaManagment.Application.Products
{
    public class SupplierListResponse
    {
        public List<SupplierResponse> Suppliers { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
