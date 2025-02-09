using AlkinanaPharmaManagment.Application.Abstractions.DriveServices;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Infrastructure.DriveServices;

public class DriveServiceImage : IDriveServices
{
    private readonly string _credentialsPath = Path.Combine(Directory.GetCurrentDirectory(), "alkinana-pharma-c6c0d655929f.json");

    public async Task<string> UploadFile(IFormFile file, string folderId)
    {
        if (file == null || file.Length == 0)
        {
            throw new Exception("No file uploaded.");
        }

        try
        {
            // تحميل بيانات الاعتماد
            var credential = GoogleCredential.FromFile(_credentialsPath)
                .CreateScoped(DriveService.ScopeConstants.DriveFile);

            // إعداد Google Drive API
            var driveService = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "GoogleDriveUploader",
            });

            // إنشاء اسم مؤقت للملف
            var tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));

            // حفظ الملف محليًا بشكل مؤقت
            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // إعداد بيانات الملف لرفعه إلى Google Drive
            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = file.FileName,
                Parents = new List<string> { folderId } // إضافة المجلد هنا
            };

            // رفع الملف إلى Google Drive
            using (var fileStream = new FileStream(tempFilePath, FileMode.Open))
            {
                var request = driveService.Files.Create(
                    fileMetadata,
                    fileStream,
                    file.ContentType
                );

                request.Fields = "id"; // حقل id فقط لأننا نحتاجه
                var result = await request.UploadAsync();

                if (result.Status == UploadStatus.Completed)
                {
                    // حذف الملف المؤقت بعد رفعه بنجاح
                    try
                    {
                        System.IO.File.Delete(tempFilePath);
                    }
                    catch (Exception deleteEx)
                    {
                        // تسجيل الخطأ إذا لم يتم حذف الملف المؤقت
                        Console.WriteLine($"Failed to delete temp file: {deleteEx.Message}");
                    }

                    return request.ResponseBody.Id;
                }
                else
                {
                    throw new Exception($"File upload failed: {result.Exception?.Message ?? "Unknown error"}");
                }
            }
        }
        catch (Exception ex)
        {
            // تحسين التعامل مع الأخطاء مع تفاصيل أكثر
            throw new Exception($"Error occurred while uploading the file: {ex.Message}", ex);
        }
    }
}

