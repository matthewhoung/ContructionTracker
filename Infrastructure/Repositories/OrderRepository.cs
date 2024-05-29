using Application.Application;
using Core.Entities.Forms;
using Core.Entities.Forms.Orders;
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
                INSERT INTO orderforms
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
        
        public async Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember)
        {
            var writeCommand = @"
                INSERT INTO orderforms_checklist
                    (order_form_id, check_role_id,user_id, is_checked)
                VALUES
                    (@OrderFormId, @CheckMemberId,@UserId, @isChecked)";
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
                    FROM orderforms";
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
                    FROM orderforms
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
                    FROM orderforms o
                    JOIN orderforms_checklist oc ON o.id = oc.order_form_id
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
