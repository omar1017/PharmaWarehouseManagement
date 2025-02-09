using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject;
using AlkinanaPharmaManagment.Domain.ValueObject;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;


namespace AlkinanaPharmaManagment.Domain.Entities
{
    public class Cart : AggregateRoot
    {
        public CartId CartId { get; private set; }
        public CustomerId CustomerId {get; private set; }
        public readonly HashSet<LineItem> lineItems = new();

        
        internal Cart(
            CartId cartId,
            CustomerId customerId,
            HashSet<LineItem> lineItems)
        {
            CartId = cartId;
            CustomerId = customerId;
            AddItems(lineItems);
        }
        public Cart() { }
        public static Cart Create(CustomerId customerId)
        {
            var cart = new Cart
            {
                CartId = new CartId(Guid.NewGuid()),
                CustomerId = customerId
            };
            return cart;
        }

        public void AddItem(ProductId productId,Price price,uint quantity)
        {
            var lineItem = new LineItem(new LineItemId(Guid.NewGuid()), productId, CartId, price, quantity);
            lineItems.Add(lineItem);

            Raise(new LineItemAdded(this, lineItem));
        }

        public void RemoveItem(LineItemId lineItemId)
        {
            var item = lineItems.FirstOrDefault(l => l.lineItemId == lineItemId);
            if (item is not null) {
                lineItems.Remove(item);
                Raise(new LineItemDeleted(this, item));
            }
        }

        public void AddItems(IEnumerable<LineItem> items)
        {
            foreach (var item in items)
            {
                AddItem(item.productId, item.price, item.quantity);
            }
        }
    }

}

