using Core.Entities.Settings.Uploader;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IUploaderRepository
    {
        Task<int> CreateFileUrlAsync(Uploader uploader, IFormFile file);
    }
}
