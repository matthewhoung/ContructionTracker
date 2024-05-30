using Core.Entities.Settings.Uploader;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IUploaderService
    {
        Task<int> UploadFileAsync(Uploader uploader, IFormFile file);
    }
}
