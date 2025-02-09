using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Delete
{
    internal class DeleteProductCommandHandler(IProductRepository productRepository) : ICommandHandler<DeleteProductCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await productRepository.DeleteAsync(request.productId);

            await productRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
