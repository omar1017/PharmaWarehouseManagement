namespace AlkinanaPharmaManagment.Application.Products
{
    public class CartSearchRequest
    {
        public string? Name { get; set; }
        public string? Pharma { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
