using Application.Interfaces;
using Core.Entities.Settings.Uploader;
using Dapper;
using System.Data;

namespace Infrastructure.Repositories
{
    public class UploaderRepository : IUploaderRepository
    {
        private readonly IDbConnection _dbConnection;

        public UploaderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<int> CreateFilePathAsync(Uploader uploader)
        {
            var writeCommand = @"
                    INSERT INTO filepaths
                        (uploader_id,
                        file_name,
                        file_path,
                        created_at,
                        updated_at)
                    VALUES
                        (@UploaderId,
                        @FileName,
                        @FilePath,
                        @CreateAt,
                        @UpdateAt);
                    SELECT LAST_INSERT_ID();";
            var parameters = new
            {
                uploader.UploaderId,
                uploader.FileName,
                uploader.FilePath,
                uploader.CreateAt,
                uploader.UpdateAt
            };
            var fileId = await _dbConnection.ExecuteScalarAsync<int>(writeCommand, parameters);
            return fileId;
        }

        public async Task UpdateFilePathAsync(UpdatePath updatePath)
        {
            // column name to be defined
            var writeCommand = @"
                    UPDATE filepaths
                    SET file_path = @FilePath
                    WHERE file_id = @FileId;";
            var parameters = new
            {
                updatePath.FileId,
                updatePath.FilePath
            };
            await _dbConnection.ExecuteAsync(writeCommand, parameters);
        }
    }
}
