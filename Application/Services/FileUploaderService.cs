using Application.Interfaces;
using Core.Entities.Settings.Uploader;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    internal class FileUploaderService : IFileUploaderService
    {
        private readonly IFileUploaderRepository _uploaderRepository;

        public FileUploaderService(IFileUploaderRepository uploaderRepository)
        {
            _uploaderRepository = uploaderRepository;
        }

        public async Task<string> DeleteFilePathAsync(int fileId)
        {
            return await _uploaderRepository.DeleteFilePathAsync(fileId);
        }

        public async Task<List<FileUploaderPath>> GetFilePathAsync(int orderFormId)
        {
            return await _uploaderRepository.GetFilePathAsync(orderFormId);
        }

        public async Task<int> UploadFileAsync(FileUploader uploader, IFormFile file)
        {
            return await _uploaderRepository.CreateFileUrlAsync(uploader, file);
        }
    }
}
