using AlkinanaPharmaManagment.Application.Products;
using MediatR;

namespace AlkinanaPharmaManagment.Application.Suppliers.GetAll
{
    public record GetSuppliersQuery(SupplierSearchRequest request):IRequest<SupplierListResponse>;

    public sealed class GetSuppliersQueryHandler(ISupplierRepository supplierRepository) : IRequestHandler<GetSuppliersQuery, SupplierListResponse>
    {
        public async Task<SupplierListResponse> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await supplierRepository.GetAll(request.request);

            if (suppliers is null)
            {
                throw new ArgumentNullException("no suppliers");
            }

            return suppliers;
        }
    }
}
