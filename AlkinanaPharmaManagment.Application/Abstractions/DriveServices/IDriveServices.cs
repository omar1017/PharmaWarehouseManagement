using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Abstractions.DriveServices
{
    public interface IDriveServices
    {
        Task<string> UploadFile(IFormFile file, string folderId);
    }
}
