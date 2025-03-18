namespace AlkinanaPharmaManagment.Application.Products
{
    public class ProductSearchRequest
    {
        public string? Name { get; set; }
        public string? SName { get; set; }
        public string? Company { get; set; }
        public string? Supplier { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
