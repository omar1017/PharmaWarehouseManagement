using AlkinanaPharmaManagment.Application.Abstractions.UploadFiles;
using AlkinanaPharmaManagment.Domain.Entities.Images;
using MediatR;

namespace AlkinanaPharmaManagment.Application.Storages.Upload
{
    public record DeleteFileCommand(Image image,string fileName):IRequest<Unit>;

    internal sealed class DeleteFileCommandHandler(IFileStorage fileStorage) : IRequestHandler<DeleteFileCommand, Unit>
    {
        public  Task<Unit> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            fileStorage.DeleteFileAsync(request.image, request.fileName);

            return Unit.Task;
        }
    }
}
