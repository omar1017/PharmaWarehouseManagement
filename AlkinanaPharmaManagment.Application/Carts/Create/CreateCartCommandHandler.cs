using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Customers;
using AlkinanaPharmaManagment.Application.Products;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Carts.Events;
using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Domain.Entities.Customers;

namespace AlkinanaPharmaManagment.Application.Carts.Create
{
    public sealed class CreateCartCommandHandler(ICartRepository cartRepository,IProductRepository productRepository,ICustomerRepository customerRepository)
        : ICommandHandler<CreateCartCommand, CartId>
    {
       
        public async Task<CartId> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
           

            var customer = Customer.CreateCustomer(
                request.cartRequest.name, 
                request.cartRequest.address, 
                request.cartRequest.pharmaName, 
                request.cartRequest.phone);

            await customerRepository.AddAsync(customer);
            await customerRepository.SaveChangeAsync();

            var cart = Cart.Create(customer.CustomerId);
            cart.CreatedAt = DateTime.UtcNow;
            
            var items = request.cartRequest.items.Select( i =>
                new LineItem(Guid.NewGuid(), i.productId, cart.CartId, i.quantity)
            );

            cart.AddItems(items);

            cart.Raise(new CartCreatedEvent(cart.CartId));

            await cartRepository.AddAsync(cart);
            
            await cartRepository.SaveChangeAsync();

            return cart.CartId;
        }
    }
}
