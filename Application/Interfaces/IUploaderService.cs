using Core.Entities.Settings.Uploader;

namespace Application.Interfaces
{
    public interface IUploaderService
    {
        Task UploadFileAsync(Uploader uploadInfo);
    }
}
