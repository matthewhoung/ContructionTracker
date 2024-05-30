using Application.Interfaces;
using Core.Entities.Settings.Uploader;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    internal class UploaderService : IUploaderService
    {
        private readonly IUploaderRepository _uploaderRepository;

        public UploaderService(IUploaderRepository uploaderRepository)
        {
            _uploaderRepository = uploaderRepository;
        }

        public async Task<int> UploadFileAsync(Uploader uploader, IFormFile file)
        {
            return await _uploaderRepository.CreateFileUrlAsync(uploader, file);
        }
    }
}
