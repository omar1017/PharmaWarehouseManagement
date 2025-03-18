namespace AlkinanaPharmaManagment.Application.Carts.Get
{
    public class CartListResponse
    {
        public List<CartResponse> Carts { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
