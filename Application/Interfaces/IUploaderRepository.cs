using Core.Entities.Settings.Uploader;

namespace Application.Interfaces
{
    public interface IUploaderRepository
    {
        Task<int> CreateFilePathAsync(Uploader uploader);
        Task UpdateFilePathAsync(UpdatePath updatePath);
    }
}
