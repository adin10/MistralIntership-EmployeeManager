using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace EmployeeManager.Common
{
    public class FileUploadHelper
    {
        public static async Task<string> Upload(IFormFile file, string rootPath)
        {
            var folderName = Path.Combine("Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(rootPath, folderName, fileName);
            var apiPath = $"https://localhost:5001/{folderName}/{fileName}";

            if (file.Length > 0)
            {
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return apiPath;
        }
    }
}
