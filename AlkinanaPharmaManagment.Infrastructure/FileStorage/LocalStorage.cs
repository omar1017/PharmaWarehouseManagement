using AlkinanaPharmaManagment.Application.Abstractions.UploadFiles;
using AlkinanaPharmaManagment.Domain.Entities.Images;
using AlkinanaPharmaManagment.Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Infrastructure.FileStorage
{
    public class LocalStorage : IFileStorage
    {
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext context;

        public LocalStorage(IWebHostEnvironment env, ApplicationDbContext context)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            this.context = context;
            if (string.IsNullOrEmpty(_env.WebRootPath))
                throw new InvalidOperationException("wwwroot folder is missing!");
        }

        public async Task<Image> UploadFileAsync(IFormFile file)
        {
            var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsPath); // إنشاء المجلد إذا لم يكن موجودًا

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var image = new Image
            {
                Id = Guid.NewGuid(),
                Url = $"https://alkinanamedstore.com/uploads/{fileName}"
            };

            context.Images.Add(image);

            context.SaveChanges();

            return image; 
        }

        public Task<List<string>> GetFilesAsync()
        {
            var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");
            return Task.FromResult(Directory.GetFiles(uploadsPath).Select(Path.GetFileName).ToList());
        }

        public void DeleteFileAsync(Image image,string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));

            var filePath = Path.Combine(_env.WebRootPath, "uploads", fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                context.Images.Remove(image);
                context.SaveChanges();
            }
            else
            {
                throw new FileNotFoundException("this file is not found");
            }
        }
    }
}
