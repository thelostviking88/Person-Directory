using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using PersonDirectory.Application.Resources;

namespace PersonDirectory.Application.Interfaces;

/// <summary>
/// File service
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Deletes File
    /// </summary>
    /// <param name="filePath">file path</param>
    /// <param name="cancellationToken">cancellation token</param>
    Task DeleteFileAsync(string filePath, CancellationToken cancellationToken);

    /// <summary>
    /// Uploads File
    /// </summary>
    /// <param name="file"></param>
    /// <param name="stringLocalizer"></param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>Uploaded file path</returns>
    Task<string> UploadFileAsync(IFormFile file, IStringLocalizer<SharedValidatorResources> stringLocalizer, CancellationToken cancellationToken);
}
