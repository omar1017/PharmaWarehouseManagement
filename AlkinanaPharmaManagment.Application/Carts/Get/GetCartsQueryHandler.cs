using AlkinanaPharmaManagment.Application.Abstractions.Messaging;

namespace AlkinanaPharmaManagment.Application.Carts.Get
{
    internal sealed class GetCartsQueryHandler(ICartRepository cartRepository)
        : IQueryHandler<GetCartsQuery,  CartListResponse>
    {
        public async Task<CartListResponse> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            var carts = await cartRepository.GetAllAsync(request.request);

            if (carts is null)
            {
                throw new ArgumentNullException(nameof(carts));
            }

            return carts;
        }
    }
}
