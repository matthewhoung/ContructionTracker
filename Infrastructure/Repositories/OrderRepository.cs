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
                    (creator_id,
                    project_id, 
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
                    (@CreatorId,
                    @ProjectId,
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

        public async Task CreateRolesAsync(Roles roles)
        {
            var writeCommand = @"
                INSERT INTO roles
                    (role_name)
                VALUES
                    (@RoleName)";
            var parameters = new {RoleName = roles.RoleName };
            await _dbConnection.ExecuteAsync(writeCommand, parameters);
        }

        public async Task CreateOrderFormCheckMember(OrderFormCheckMember orderFormCheckMember)
        {
            var writeCommand = @"
                INSERT INTO order_form_checks
                    (order_form_id, check_role_id, is_checked)
                VALUES
                    (@OrderFormId, @CheckMemberId, @isChecked)";
            var parameters = new { OrderFormId = orderFormCheckMember.OrderFormId, CheckMemberId = orderFormCheckMember.OrderRoleId, isChecked = orderFormCheckMember.isChecked };
            await _dbConnection.ExecuteAsync(writeCommand, parameters);
        }

        public async Task<List<OrderForm>> GetOrderAllAsync()
        {
            var readCommand = @"
                    SELECT 
                        id AS Id,
                        creator_id AS CreatorId,
                        project_id AS ProjectId, 
                        order_name AS OrderName, 
                        order_description AS OrderDescription, 
                        worker_type_id AS WorkerTypeId, 
                        worker_team_id AS WorkerTeamId, 
                        department_id AS DepartmentId, 
                        pay_amount AS PayAmount, 
                        pay_type_id AS PayTypeId, 
                        pay_by_id AS PayById, 
                        created_at AS CreatedAt, 
                        updated_at AS UpdatedAt
                    FROM order_forms";
            var orders = await _dbConnection.QueryAsync<OrderForm>(readCommand);
            return orders.ToList();
        }

        public async Task<OrderForm> GetOrderByIdAsync(int orderFormId)
        {
            var readCommand = @"
                    SELECT 
                        id AS Id,
                        creator_id AS CreatorId,
                        project_id AS ProjectId, 
                        order_name AS OrderName, 
                        order_description AS OrderDescription, 
                        worker_type_id AS WorkerTypeId, 
                        worker_team_id AS WorkerTeamId, 
                        department_id AS DepartmentId, 
                        pay_amount AS PayAmount, 
                        pay_type_id AS PayTypeId, 
                        pay_by_id AS PayById, 
                        created_at AS CreatedAt, 
                        updated_at AS UpdatedAt
                    FROM order_forms
                    WHERE id = @Id";
            var parameters = new { Id = orderFormId };
            var orders = await _dbConnection.QuerySingleOrDefaultAsync<OrderForm>(readCommand, parameters);
            return orders;
        }

        public async Task<List<OrderFormStatus>> GetOrderFormStatusAsync(int orderFormId)
        {
            var readCommand = @"
                    SELECT
                        o.id,
                        o.order_name,
                        r.role_name AS RoleName,
                        oc.user_id AS UserId,
                        oc.is_checked AS isChecked
                    FROM order_forms o
                    JOIN order_form_checks oc ON o.id = oc.order_form_id
                    JOIN roles r ON oc.check_role_id = r.role_id
                    WHERE o.id = @OrderFormId;";
            var getStatus = await _dbConnection.QueryAsync<OrderFormStatus>(readCommand, new { OrderFormId = orderFormId });
            return getStatus.ToList();
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

        public Task<IReadOnlyList<WorkerClass>> GetWorkerClassesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
