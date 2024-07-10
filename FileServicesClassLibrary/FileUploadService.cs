
using Microsoft.AspNetCore.Http;
using System.IO;

namespace FileServicesClassLibrary
{
    public class FileUploadService : IFileUploadService
    {
        public async Task<string> SaveFileAsync(DocEntity file)
        {
            try
            {
                string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                // Ensure the directory exists
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Generate a unique name for the file
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.PdfFile.FileName);
                string filePath = Path.Combine(directoryPath, uniqueFileName);

                // Save the file
                using (Stream stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.PdfFile.CopyToAsync(stream);
                }

                return filePath;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

    }

    public class DocEntity
    {
        public IFormFile? PdfFile { get; set; }
    }
}
