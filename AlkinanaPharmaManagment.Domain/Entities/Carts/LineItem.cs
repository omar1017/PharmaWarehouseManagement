using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject;
using AlkinanaPharmaManagment.Domain.ValueObject;


namespace AlkinanaPharmaManagment.Domain.Entities
{
    public class LineItem
    { 
        public LineItemId lineItemId { get; private set; }
        public ProductId productId { get; private set; }
        public Product Product { get; private set; }
        public CartId cartId {get; private set; }
        public Cart Cart { get; private set; }
        public int quantity {get; private set; }
        public bool isFulfilled { get; set; } = false;
        public LineItem(
            LineItemId lineItemId,
            ProductId productId,
            CartId cartId,
            int quantity
            )
        {
            this.lineItemId = lineItemId;
            this.productId = productId;
            this.cartId = cartId;
            this.quantity = quantity;
        }
        
    }


}

