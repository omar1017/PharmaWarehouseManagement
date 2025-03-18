namespace AlkinanaPharmaManagment.Application.Products
{
    public class SupplierSearchRequest
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
