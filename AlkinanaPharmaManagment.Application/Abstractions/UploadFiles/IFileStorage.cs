using AlkinanaPharmaManagment.Domain.Entities.Images;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Abstractions.UploadFiles
{
    public interface IFileStorage
    {
        Task<Image> UploadFileAsync(IFormFile file);
        Task<List<string>> GetFilesAsync();
        void DeleteFileAsync(Image image,string fileName);
    }
}
