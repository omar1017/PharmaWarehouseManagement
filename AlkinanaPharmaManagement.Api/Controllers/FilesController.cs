using AlkinanaPharmaManagment.Application.Storages.Upload;
using AlkinanaPharmaManagment.Domain.Entities.Images;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlkinanaPharmaManagement.Api.Controllers
{
    [Authorize(Roles = "Administrator, CustomerAccount")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ISender sender;

        public FilesController(ISender sender)
        {
            this.sender = sender;
        }

        

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file) => Ok(await sender.Send(new UploadFileCommand(file)));

        [HttpPost("{fileName}")]
        public async Task<IActionResult> DeleteFile(Image image,string fileName)
        {
            await sender.Send(new DeleteFileCommand(image, fileName));
            return NoContent();
        }
            
    }
}
