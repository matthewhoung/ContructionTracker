using Core.Entities.Forms;
using Dapper;
using System.Data;

namespace Infrastructure.Repositories
{
    public class OrderRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<ReceiveForm>> GetAllAsync()
        {
            var sql = @"
            SELECT 
                rf.ReceiveId, rf.IsChecked, rf.ReceiveItem,
                of.Id, of.CreatorId, of.ProjectId, of.WorkerType, 
                of.WorkerTeam, of.Department, of.PayAmount, of.PayType
            FROM ReceiveForms rf
            JOIN OrderForms of ON rf.Id = of.Id";

            var result = await _dbConnection.QueryAsync<ReceiveForm, OrderForm, ReceiveForm>(
                sql,
                (rf, of) =>
                {
                    rf.Id = of.Id;
                    rf.CreatorId = of.CreatorId;
                    rf.ProjectId = of.ProjectId;
                    rf.WorkerType = of.WorkerType;
                    rf.WorkerTeam = of.WorkerTeam;
                    rf.Department = of.Department;
                    rf.PayAmount = of.PayAmount;
                    rf.PayType = of.PayType;
                    return rf;
                },
                splitOn: "Id");

            return result;
        }

        public async Task<int> InsertAsync(ReceiveForm receiveForm)
        {
            var sql = @"
            INSERT INTO OrderForms (CreatorId, ProjectId, WorkerType, WorkerTeam, Department, PayAmount, PayType)
            VALUES (@CreatorId, @ProjectId, @WorkerType, @WorkerTeam, @Department, @PayAmount, @PayType);
            INSERT INTO ReceiveForms (Id, IsChecked, ReceiveItem)
            VALUES (@Id, @IsChecked, @ReceiveItem);
            SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new
            {
                receiveForm.CreatorId,
                receiveForm.ProjectId,
                receiveForm.WorkerType,
                receiveForm.WorkerTeam,
                receiveForm.Department,
                receiveForm.PayAmount,
                receiveForm.PayType,
                receiveForm.Id,
                receiveForm.IsChecked,
                receiveForm.ReceiveItem
            };

            var id = await _dbConnection.QuerySingleAsync<int>(sql, parameters);
            return id;
        }
    }
}
