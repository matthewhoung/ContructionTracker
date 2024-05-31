using Application.Interfaces;
using Core.Entities.Settings.Uploader;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Repositories
{
    public class UploaderRepository : IUploaderRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public UploaderRepository(IDbConnection dbConnection, IWebHostEnvironment environment, IConfiguration configuration)
        {
            _dbConnection = dbConnection;
            _environment = environment;
            _configuration = configuration;
        }

        public async Task<int> CreateFileUrlAsync(Uploader uploader, IFormFile file)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();
                var transaction = _dbConnection.BeginTransaction();
                try
                {
                    var fileFullPath = await GenerateFilePath(uploader.OrderFormId, file);
                    var writeCommand = @"
                        INSERT INTO orderforms_filepaths
                            (orderform_id,
                            uploader_id,
                            file_name,
                            file_path,
                            created_at,
                            updated_at)
                        VALUES
                            (@OrderFormId,
                            @UploaderId,
                            @FileName,
                            @FilePath,
                            @CreateAt,
                            @UpdateAt);
                        SELECT LAST_INSERT_ID();";
                    var parameters = new
                    {
                        OrderFormId = uploader.OrderFormId,
                        UploaderId = uploader.UploaderId,
                        FileName = Path.GetFileName(fileFullPath),
                        FilePath = fileFullPath,
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    };
                    var fileId = await _dbConnection.ExecuteScalarAsync<int>(writeCommand, parameters, transaction);
                    transaction.Commit();
                    await StoreFileAsync(file, fileFullPath);
                    return fileId;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        private async Task<string> GenerateFilePath(int orderFormId, IFormFile file)
        {
            var currentMaxIncrement = await GetOrderFormMaxIncrement(orderFormId);

            int autoIncrement = currentMaxIncrement + 1;

            string rootPath = _configuration["FileUploadPath"];
            DateTime now = DateTime.Now;
            string extension = Path.GetExtension(file.FileName);
            string fileName = now.ToString("yyyy-MM-dd") + $"-{autoIncrement}" + extension;
            string filePath = Path.Combine(rootPath, orderFormId.ToString(),fileName);

            return filePath;
        }

        private async Task<int> GetOrderFormMaxIncrement(int orderFormId)
        {
            var readCommand = @"
                SELECT COUNT(file_path)
                FROM orderforms_filepaths
                WHERE orderform_id = @OrderFormId";
            var parameters = new { OrderFormId = orderFormId };
            var maxIncrement = await _dbConnection.ExecuteScalarAsync<int>(readCommand, parameters);
            return maxIncrement;
        }

        private async Task StoreFileAsync(IFormFile file, string filePath)
        {
            var directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }
    }
}
