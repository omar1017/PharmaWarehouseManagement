using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject;
using AlkinanaPharmaManagment.Domain.ValueObject;


namespace AlkinanaPharmaManagment.Domain.Entities
{
    public class LineItem
    { 
        public LineItemId lineItemId { get; private set; }
        public ProductId productId { get; private set; }
        public CartId cartId {get; private set; }
        public uint quantity {get; private set; }
        public Price price {get; private set; }
        public LineItem(
            LineItemId lineItemId,
            ProductId productId,
            CartId cartId,
            Price price,
            uint quantity
            )
        {
            this.lineItemId = lineItemId;
            this.productId = productId;
            this.cartId = cartId;
            this.price = price;
            this.quantity = quantity;
        }
        
    }


}

