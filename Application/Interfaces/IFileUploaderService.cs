using Core.Entities.Settings.Uploader;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IFileUploaderService
    {
        Task<int> UploadFileAsync(FileUploader uploader, IFormFile file);
    }
}
