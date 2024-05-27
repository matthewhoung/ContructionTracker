using Application.Application;
using Core.Entities.Forms;
using Core.Entities.Settings;
using Dapper;
using System.Data;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> CreateOrderAsync(OrderForm order)
        {
            var writeCommand = @"
                INSERT INTO order_forms
                    (project_id, 
                    creator_id,
                    creator_checked,
                    supervisor_id,
                    supervisor_checked,
                    director_id,
                    director_checked,
                    order_name,
                    order_description,
                    worker_type_id,
                    worker_team_id,
                    department_id,
                    pay_amount,
                    pay_type_id,
                    pay_by_id,
                    created_at,
                    updated_at)
                VALUES
                    (@ProjectId,
                    @CreatorId,
                    @CreatorChecked,
                    @SupervisorId,
                    @SupervisorChecked,
                    @DirectorId,
                    @DirectorChecked,
                    @OrderName,
                    @OrderDescription,
                    @WorkerTypeId,
                    @WorkerTeamId,
                    @DepartmentId,
                    @PayAmount,
                    @PayTypeId,
                    @PayById,
                    @CreatedAt,
                    @UpdatedAt);
                SELECT LAST_INSERT_ID();";
            return await _dbConnection.ExecuteScalarAsync<int>(writeCommand, order);
        }
        public Task<int> CreatOrderItemAsync(OrderItems orderItems)
        {
            throw new NotImplementedException();
        }


        public async Task CreateWorkerClassAsync(WorkerClass workerClass)
        {
           var writeCommand = @"
                INSERT INTO worker_class
                    (worker_class_id, worker_class_name)
                VALUES
                    (@WorkerClassId, @WorkerClassName)";
            var parameters = new { WorkerClassId = workerClass.WorkerClassId, WorkerClassName = workerClass.WorkerClassName };
            await _dbConnection.ExecuteAsync(writeCommand, parameters);
        }

        public async Task CreateWorkerTypeAsync(WorkerType workerType)
        {
            var writeCommand = @"
                INSERT INTO worker_types
                    (worker_type_id, worker_class_id, worker_type_name)
                VALUES
                    (@WorkerTypeId, @WorkerClassId, @WorkerTypeName)";
            var parameters = new { WorkerTypeId = workerType.WokerTypeId, WorkerClassId = workerType.WorkerClassId, WorkerTypeName = workerType.WorkerTypeName };
            await _dbConnection.ExecuteAsync(writeCommand, parameters);
        }

        public async Task CreateWorkerTeamAsync(WorkerTeam workerTeam)
        {
            var writeCommand = @"
                INSERT INTO worker_teams
                    (worker_team_id, 
                    worker_type_id, 
                    worker_team_name, 
                    worker_contact_name, 
                    worker_contact_number, 
                    worker_contact_address, 
                    worker_account_code, 
                    worker_account_name, 
                    worker_account_number)
                VALUES
                    (@WorkerTeamId, 
                    @WorkerTypeId, 
                    @WorkerTeamName, 
                    @ContactName, 
                    @ContactNumber, 
                    @ContactAddress, 
                    @AccountCode, 
                    @AccountName, 
                    @AccountNumber)";
            var parameters = new
            {
                WorkerTeamId = workerTeam.WorkerTeamId,
                WorkerTypeId = workerTeam.WorkerTypeId,
                WorkerTeamName = workerTeam.WorkerTeamName,
                ContactName = workerTeam.ContactName,
                ContactNumber = workerTeam.ContactNumber,
                ContactAddress = workerTeam.ContactAddress,
                AccountCode = workerTeam.AccountCode,
                AccountName = workerTeam.AccountName,
                AccountNumber = workerTeam.AccountNumber
            };
            await _dbConnection.ExecuteAsync(writeCommand, parameters);
        }

        public async Task CreateDepartmentAsync(Department department)
        {
            var writeCommand = @"
                INSERT INTO departments
                    (department_id, department_name)
                VALUES
                    (@DepartmentId, @DepartmentName)";
            var parameters = new { DepartmentId = department.DepartmentId, DepartmentName = department.DepartmentName };
            await _dbConnection.ExecuteAsync(writeCommand, parameters);
        }

        public async Task CreatePayByAsync(PayBy payBy)
        {
            var writeCommand = @"
                INSERT INTO pay_by
                    (pay_by_id, pay_by_name)
                VALUES
                    (@PayById, @PayByName)";
            var parameters = new { PayById = payBy.PayById, PayByName = payBy.PayByName };
            await _dbConnection.ExecuteAsync(writeCommand, parameters);
        }

        public async Task CreatePayTypeAsync(PayType payType)
        {
            var writeCommand = @"
                INSERT INTO pay_types
                    (pay_type_id, pay_type_name)
                VALUES
                    (@PayTypeId, @PayTypeName)";
            var parameters = new { PayTypeId = payType.PayTypeId, PayTypeName = payType.PayTypeName };
            await _dbConnection.ExecuteAsync(writeCommand, parameters);
        }

        public async Task CreateUnitAsync(UnitClass unitClass)
        {
            var writeCommand = @"
                INSERT INTO units
                    (unit_id, unit_name)
                VALUES
                    (@UnitId, @UnitName)";
            var parameters = new { UnitId = unitClass.UnitId, UnitName = unitClass.UnitName };
            await _dbConnection.ExecuteAsync(writeCommand, parameters);
        }

        public Task<OrderForm> GetOrderAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderForm> GetOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<PayBy>> GetPayByAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<PayType>> GetPayTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<WorkerTeam>> GetWorkerTeamsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<WorkerType>> GetWorkerTypesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
