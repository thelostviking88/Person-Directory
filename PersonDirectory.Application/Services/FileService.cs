using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using PersonDirectory.Application.Interfaces;
using PersonDirectory.Application.Resources;

namespace PersonDirectory.Application.Services
{
    public class FileService(string imagePath) : IFileService
    {
        public async Task DeleteFileAsync(string filePath, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                await Task.Factory.StartNew(() => File.Delete(filePath), cancellationToken);
            }
        }

        public async Task<string> UploadFileAsync(IFormFile file, IStringLocalizer<SharedValidatorResources> localizer, CancellationToken cancellationToken)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception(localizer["NoFileUploaded"]);
            }

            if (!file.ContentType.StartsWith("image/"))
            {
                throw new Exception(localizer["OnlyImages"]);
            }

            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }

            string fileExtension = Path.GetExtension(file.FileName);
            string uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";

            string fullFilePath = Path.Combine(imagePath, uniqueFileName);

            using (var stream = new FileStream(fullFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream, cancellationToken);
            }

            return fullFilePath;
        }

    }
}
