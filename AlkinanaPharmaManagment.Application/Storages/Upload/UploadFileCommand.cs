using AlkinanaPharmaManagment.Application.Abstractions.UploadFiles;
using AlkinanaPharmaManagment.Domain.Entities.Images;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Storages.Upload
{
    public record UploadFileCommand(IFormFile file) : IRequest<Image>;

    internal sealed class UploadFileCommandHandler(IFileStorage fileStorage) : IRequestHandler<UploadFileCommand, Image>
    {
        public async Task<Image> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var image = await fileStorage.UploadFileAsync(request.file);

            if(image is null)
            {
                throw new Exception("failed upload image");
            }

            return image;
        }
    }
}
