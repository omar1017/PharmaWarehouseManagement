namespace AlkinanaPharmaManagment.Application.Products.Get
{
    public class SupplierResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
    }
}