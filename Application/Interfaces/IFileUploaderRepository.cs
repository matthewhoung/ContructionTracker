using Core.Entities.Settings.Uploader;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IFileUploaderRepository
    {
        Task<int> CreateFileUrlAsync(FileUploader uploader, IFormFile file);
        Task<List<FileUploaderPath>> GetFilePathAsync(int orderFormId);
        Task<string> DeleteFilePathAsync(int fileId);
    }
}
