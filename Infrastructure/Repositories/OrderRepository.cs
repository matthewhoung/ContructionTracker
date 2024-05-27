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
                        pay_by,
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
                        @WorkerType.Id,
                        @WorkerTeam.Id,
                        @Department.Id,
                        @PayAmount,
                        @PayBy.Id,
                        @CreatedAt,
                        @UpdatedAt);
                    SELECT LAST_INSERT_ID();";
            return await _dbConnection.ExecuteScalarAsync<int>(writeCommand, order);
        }

        public Task<int> CreatOrderItemAsync(OrderItems orderItems)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Department>> GetDepartmentsAsync()
        {
            throw new NotImplementedException();
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
