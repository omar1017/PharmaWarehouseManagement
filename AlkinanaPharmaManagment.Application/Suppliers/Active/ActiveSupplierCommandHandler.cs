using AlkinanaPharmaManagment.Application.Abstractions.Identity;
using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Exceptions;
using MediatR;

namespace AlkinanaPharmaManagment.Application.Suppliers.Active
{
    internal sealed class ActiveSupplierCommandHandler(ISupplierRepository supplierRepository,IUserService userService) : ICommandHandler<ActiveSupplierCommand, Unit>
    {
        public async Task<Unit> Handle(ActiveSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await supplierRepository.GetAsync(request.supplierId);

            if(supplier is null)
            {
                throw new NotFoundException(nameof(supplier),request.supplierId);
            }

            await userService.ConfirmAccount(supplier.UserId);

            return Unit.Value;

        }
    }
}
