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

        public async Task<int> UploadFileAsync(FileUploader uploader, IFormFile file)
        {
            return await _uploaderRepository.CreateFileUrlAsync(uploader, file);
        }
    }
}
