using Application.Application;
using Core.Entities.Forms;
using Core.Entities.Forms.Orders;
using Core.Entities.Settings;
using Dapper;
using System.Data;

namespace Infrastructure.Repositories
{
    public class OrderFormRepository : IOrderFormRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrderFormRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        /*
         * Create Section
         */
        public async Task<int> CreateOrderAsync(OrderForm order)
        {
            var writeCommand = @"
                    INSERT INTO orderforms
                        (creator_id,
                        project_id, 
                        order_name,
                        order_description,
                        created_at,
                        updated_at)
                    VALUES
                        (@CreatorId,
                        @ProjectId,
                        @OrderName,
                        @OrderDescription,
                        @CreatedAt,
                        @UpdatedAt);
                    SELECT LAST_INSERT_ID();";
            return await _dbConnection.ExecuteScalarAsync<int>(writeCommand, order);
        }
        public async Task<int> CreatOrderDetailAsync(OrderFormDetail orderItems)
        {
            var writeCommand = @"
                        INSERT INTO orderforms_details
                            (detail_id, 
                            orderform_id, 
                            item_name,
                            item_description, 
                            quantity,
                            unit_price,
                            unit_id, 
                            total_price, 
                            item_ischeck)
                        VALUES
                            (@DetailId, 
                            @OrderId, 
                            @ItemName, 
                            @ItemDescription, 
                            @Quantity, 
                            @UnitPrice, 
                            @UnitNameId, 
                            @TotalPrice, 
                            @IsChecked);
                        SELECT LAST_INSERT_ID();";
            return await _dbConnection.ExecuteScalarAsync<int>(writeCommand, orderItems);
        }

        public async Task<int> CreateOrderPayInfo(OrderFormPayInfo paymentInfo)
        {
            var writeCommand = @"
                    INSERT INTO orderforms_payinfo
                        (orderform_id, 
                        pay_amount, 
                        pay_type_id, 
                        pay_by_id)
                    VALUES
                        (@OrderId, 
                        @PaymentAmount, 
                        @PaymentTypeId, 
                        @PaymentById);
                    SELECT LAST_INSERT_ID();";
            return await _dbConnection.ExecuteScalarAsync<int>(writeCommand, paymentInfo);
        }
        
        public async Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember)
        {
            var writeCommand = @"
                    INSERT INTO orderforms_checklist
                        (orderform_id, 
                        role_id,
                        user_id, 
                        is_checked)
                    VALUES
                        (@OrderId, 
                        @CheckMemberId,
                        @UserId, 
                        @isChecked)";
            var parameters = new 
            { 
                OrderId = orderFormCheckMember.OrderId, 
                CheckMemberId = orderFormCheckMember.OrderRoleId,
                UserId = orderFormCheckMember.UserId,
                isChecked = orderFormCheckMember.isChecked };
            await _dbConnection.ExecuteAsync(writeCommand, parameters);
        }

        public async Task<int> CreateOrderFormWorkerList(OrderFormWorker workerList)
        {
            var writeCommand = @"
                    INSERT INTO orderforms_workers
                        (orderform_id, 
                        worker_type_id, 
                        worker_team_id)
                    VALUES
                        (@OrderId, 
                        @WorkerTypeId, 
                        @WorkerTeamId);
                    SELECT LAST_INSERT_ID();";
            return await _dbConnection.ExecuteScalarAsync<int>(writeCommand, workerList);
        }

        public async Task<int> CreatOrderFormDepartmentAsync(OrderFormDepartment department)
        {
            var writeCommand = @"
                    INSERT INTO orderforms_department
                        (orderform_id, department_id)
                    VALUES
                        (@OrderId, @DepartmentId);
                    SELECT LAST_INSERT_ID();";
            var departmentId = await _dbConnection.ExecuteScalarAsync<int>(writeCommand, department);
            return departmentId;
        }

        /*
         * Read Section
         */

        public async Task<List<OrderForm>> GetOrderAllAsync()
        {
            var readCommand = @"
                    SELECT 
                        id AS Id,
                        creator_id AS CreatorId,
                        project_id AS ProjectId,
                        status AS Status,
                        order_name AS OrderName, 
                        order_description AS OrderDescription,  
                        created_at AS CreatedAt, 
                        updated_at AS UpdatedAt
                    FROM orderforms";
            var orders = await _dbConnection.QueryAsync<OrderForm>(readCommand);
            return orders.AsList();
        }

        public async Task<OrderForm> GetOrderByIdAsync(int orderFormId)
        {
            var readCommand = @"
                    SELECT 
                        id AS Id,
                        creator_id AS CreatorId,
                        project_id AS ProjectId,
                        status AS Status,
                        order_name AS OrderName,
                        order_description AS OrderDescription,  
                        created_at AS CreatedAt, 
                        updated_at AS UpdatedAt
                    FROM orderforms
                    WHERE id = @Id";
            var parameters = new { Id = orderFormId };
            var orders = await _dbConnection.QuerySingleOrDefaultAsync<OrderForm>(readCommand, parameters);
            return orders;
        }

        public async Task<List<OrderForm>> GetOrderByUserAsync(int userId)
        {
            var readCommand = @"
                    SELECT 
                        id AS Id,
                        creator_id AS CreatorId,
                        project_id AS ProjectId,
                        status AS Status,
                        order_name AS OrderName,
                        order_description AS OrderDescription, 
                        created_at AS CreatedAt, 
                        updated_at AS UpdatedAt
                    FROM orderforms
                    WHERE creator_id = @UserId";
            var parameters = new { UserId = userId };
            var orders = await _dbConnection.QueryAsync<OrderForm>(readCommand, parameters);
            return orders.AsList();
        }

        public async Task<List<OrderFormDetail>> GetOrderDetailAsync(int orderFormId)
        {
            var readCommand = @"
                    SELECT 
                        detail_id AS DetailId,
                        orderform_id AS OrderId,
                        item_name AS ItemName,
                        item_description AS ItemDescription,
                        quantity AS Quantity,
                        unit_price AS UnitPrice,
                        unit_id AS UnitNameId,
                        total_price AS TotalPrice,
                        item_ischeck AS IsChecked
                    FROM orderforms_details
                    WHERE orderform_id = @OrderFormId";
            var parameters = new { OrderFormId = orderFormId };
            var orderDetails = await _dbConnection.QueryAsync<OrderFormDetail>(readCommand, parameters);
            return orderDetails.AsList();
        }

        public async Task<List<OrderFormStatus>> GetOrderFormSignitureAsync(int orderFormId)
        {
            var readCommand = @"
                    SELECT
                        o.id AS OrderId,
                        o.order_name AS OrderName,
                        r.role_name AS RoleName,
                        oc.user_id AS UserId,
                        oc.is_checked AS isChecked
                    FROM orderforms o
                    JOIN orderforms_checklist oc ON o.id = oc.orderform_id
                    JOIN roles r ON oc.role_id = r.role_id
                    WHERE o.id = @OrderFormId;";
            var getStatus = await _dbConnection.QueryAsync<OrderFormStatus>(readCommand, new { OrderFormId = orderFormId });
            return getStatus.AsList();
        }

        public async Task<OrderFormPayInfo> GetOrderFormPayInfoAsync(int orderFormId)
        {
            var readCommand = @"
                    SELECT 
                        o.id AS OrderId,
                        p.pay_amount AS PaymentAmount,
                        p.pay_type_id AS PaymentTypeId,
                        p.pay_by_id AS PaymentById
                    FROM orderforms o
                    JOIN orderforms_payinfo p ON o.id = p.orderform_id
                    WHERE o.id = @OrderFormId";
            var parameters = new { OrderFormId = orderFormId };
            var orderFormPayInfo = await _dbConnection.QuerySingleOrDefaultAsync<OrderFormPayInfo>(readCommand, parameters);
            return orderFormPayInfo;
        }

        public async Task<List<OrderFormWorker>> GetOrderFormWorkerAsync(int orderFormId)
        {
            var query = @"
                    SELECT 
                        o.id AS OrderId,
                        ow.worker_type_id AS WorkerTypeId,
                        ow.worker_team_id AS WorkerTeamId
                    FROM orderforms o
                    JOIN orderforms_workers ow ON o.id = ow.orderform_id
                    JOIN worker_types wt ON ow.worker_type_id = wt.worker_type_id
                    JOIN worker_teams wtm ON ow.worker_team_id = wtm.worker_team_id
                    WHERE o.id = @OrderFormId";
            var parameters = new { OrderFormId = orderFormId };
            var orderFormWithWorkers = await _dbConnection.QueryAsync<OrderFormWorker>(query, parameters);
            return orderFormWithWorkers.AsList();
        }

        public async Task<List<OrderFormDepartment>> GetOrderFormDepartmentAsync(int orderFormId)
        {
            var query = @"
                    SELECT 
                        o.id AS OrderId,
                        od.department_id AS DepartmentId,
                        d.department_name AS DepartmentName
                    FROM orderforms o
                    JOIN orderforms_department od ON o.id = od.orderform_id
                    JOIN departments d ON od.department_id = d.department_id
                    WHERE o.id = @OrderFormId";
            var parameters = new { OrderFormId = orderFormId };
            var orderFormWithDepartment = await _dbConnection.QueryAsync<OrderFormDepartment>(query, parameters);
            return orderFormWithDepartment.AsList();
        }


        public async Task<Dictionary<string, int>> GetOrderFormStatusCountAsync()
        {
            var readCommand = @"
                    SELECT
                        status,
                        COUNT(*) AS Count
                    FROM orderforms
                    GROUP BY status";

            var statusCounts = await _dbConnection.QueryAsync<(string Status, int Count)>(readCommand);

            var result = statusCounts.ToDictionary(item => item.Status, item => item.Count);

            return result;
        }

        public async Task<string> GetOrderFormStatus(int orderfromId)
        {
            var readCommand = @"
                    SELECT
                        status
                    FROM orderforms
                    WHERE id = @OrderFormId";
            var parameters = new { OrderFormId = orderfromId };
            var status = await _dbConnection.QuerySingleOrDefaultAsync<string>(readCommand, parameters);
            return status;
        }

        /*
         * Update Section
         */
        public async Task UpdateOrderDetailAsync(OrderFormDetail orderItems)
        {
            var updateCommand = @"
                    UPDATE orderforms_details
                    SET 
                        item_name = @ItemName,
                        item_description = @ItemDescription,
                        quantity = @Quantity,
                        unit_price = @UnitPrice,
                        unit_id = @UnitNameId,
                        total_price = @TotalPrice,
                        item_ischeck = @IsChecked
                    WHERE detail_id = @DetailId AND orderform_id = @OrderFormId";
            var parameter = new
            {
                ItemName = orderItems.ItemName,
                ItemDescription = orderItems.ItemDescription,
                Quantity = orderItems.Quantity,
                UnitPrice = orderItems.UnitPrice,
                UnitNameId = orderItems.UnitNameId,
                TotalPrice = orderItems.TotalPrice,
                IsChecked = orderItems.IsChecked,
                DetailId = orderItems.DetailId,
                OrderFormId = orderItems.OrderId
            };
            await _dbConnection.ExecuteAsync(updateCommand, parameter);
        }

        public async Task UpdateOrderFormPayInfoAsync(OrderFormPayInfo paymentInfo)
        {
            var updateCommand = @"
                    UPDATE orderforms_payinfo
                    SET pay_amount = @PaymentAmount,
                        pay_type_id = @PaymentTypeId,
                        pay_by_id = @PaymentById
                    WHERE orderform_id = @OrderId";
            var parameter = new
            {
                PaymentAmount = paymentInfo.PaymentAmount,
                PaymentTypeId = paymentInfo.PaymentTypeId,
                PaymentById = paymentInfo.PaymentById,
                OrderId = paymentInfo.OrderId
            };
            await _dbConnection.ExecuteAsync(updateCommand, parameter);
        }

        public async Task UpdateWorkerAsync(OrderFormWorker workerList)
        {
            var updateCommand = @"
                    UPDATE orderforms_workers
                    SET worker_type_id = @WorkerTypeId,
                        worker_team_id = @WorkerTeamId
                    WHERE orderform_id = @OrderId";
            var parameter = new
            {
                WorkerTypeId = workerList.WorkerTypeId,
                WorkerTeamId = workerList.WorkerTeamId,
                OrderId = workerList.OrderId
            };
            await _dbConnection.ExecuteAsync(updateCommand, parameter);
        }

        public async Task UpdateStatusAsync(int orderFormId)
        {
            var checklist = await GetOrderFormSignitureAsync(orderFormId);

            var allChecked = checklist.All(item => item.isChecked);
            var creatorChecked = checklist.Any(item => item.RoleName == "Creator" && item.isChecked);

            var status = allChecked ? "已審核" : (creatorChecked ? "審核中" : "編輯中");

            var updateCommand = @"
                    UPDATE orderforms
                    SET status = @Status
                    WHERE id = @OrderFormId";
            var parameters = new { Status = status, OrderFormId = orderFormId };
            await _dbConnection.ExecuteAsync(updateCommand, parameters);
        }

        public async Task UpdateSignatureAsync(int orderFormId, int userId, bool isChecked)
        {
            var updateCommand = @"
                    UPDATE orderforms_checklist
                    SET is_checked = @IsChecked
                    WHERE orderform_id = @OrderFormId AND user_id = @UserId";
            var parameters = new 
            {
                IsChecked = isChecked,
                OrderFormId = orderFormId,
                UserId = userId
            };
            await _dbConnection.ExecuteAsync(updateCommand, parameters);

            await UpdateStatusAsync(orderFormId);
        }

        /*
         * Delete Section
         */

        public async Task DeleteOrderDetailAsync(int orderformId)
        {
            var deleteCommand = @"
                    DELETE FROM orderforms_details
                    WHERE orderform_id = @OrderItemId";
            var parameters = new { OrderItemId = orderformId };
            await _dbConnection.ExecuteAsync(deleteCommand, parameters);
        }
    }
}
