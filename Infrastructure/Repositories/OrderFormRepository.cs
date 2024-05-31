﻿using Application.Application;
using Application.DTOs;
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

        public async Task<int> CreateOrderAsync(OrderForm order)
        {
            var writeCommand = @"
                    INSERT INTO orderforms
                        (creator_id,
                        project_id, 
                        order_name,
                        order_description,
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
                        @DepartmentId,
                        @PayAmount,
                        @PayTypeId,
                        @PayById,
                        @CreatedAt,
                        @UpdatedAt);
                    SELECT LAST_INSERT_ID();";
            return await _dbConnection.ExecuteScalarAsync<int>(writeCommand, order);
        }
        public async Task<int> CreatOrderDetailAsync(OrderItems orderItems)
        {
            var writeCommand = @"
                        INSERT INTO orderforms_details
                            (detail_id, orderform_id, item_name,item_description, quantity,unit_price ,unit_id , total_price, item_ischeck)
                        VALUES
                            (@DetailId, @OrderItemId, @ItemName, @ItemDescription, @Quantity, @UnitPrice, @UnitNameId, @TotalPrice, @IsChecked);
                        SELECT LAST_INSERT_ID();";
            return await _dbConnection.ExecuteScalarAsync<int>(writeCommand, orderItems);
        }

        public async Task<int> CreateOrderPayInfo(OrderFormPayInfo paymentInfo)
        {
            var writeCommand = @"
                    INSERT INTO orderforms_payinfo
                        (orderform_id, pay_amount, pay_type_id, pay_by_id)
                    VALUES
                        (@OrderFormId, @PaymentAmount, @PaymentTypeId, @PaymentById);
                    SELECT LAST_INSERT_ID();";
            return await _dbConnection.ExecuteScalarAsync<int>(writeCommand, paymentInfo);
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

        public async Task<int> CreateOrderFormWorkerList(OrderFromWorkerDto workerList)
        {
            var writeCommand = @"
                    INSERT INTO orderforms_workers
                        (orderform_id, worker_type_id, worker_team_id)
                    VALUES
                        (@OrderFormId, @WorkerTypeId, @WorkerTeamId);
                    SELECT LAST_INSERT_ID();";
            return await _dbConnection.ExecuteScalarAsync<int>(writeCommand, workerList);
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
                        department_id AS DepartmentId, 
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
                        department_id AS DepartmentId, 
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

        public async Task<OrderFormPaymentDto> GetOrderFormPayInfoAsync(int orderFormId)
        {
            var readCommand = @"
                    SELECT 
                        o.id AS Id,
                        o.creator_id AS CreatorId,
                        o.project_id AS ProjectId,
                        o.order_name AS OrderName,
                        o.order_description AS OrderDescription,
                        o.department_id AS DepartmentId,
                        o.created_at AS CreatedAt,
                        o.updated_at AS UpdatedAt,
                        p.pay_amount AS PayAmount,
                        p.pay_type_id AS PayTypeId,
                        p.pay_by_id AS PayById
                    FROM orderforms o
                    JOIN orderforms_payinfo p ON o.id = p.orderform_id
                    WHERE o.id = @OrderFormId";
            var parameters = new { OrderFormId = orderFormId };
            var orderFormPayInfo = await _dbConnection.QuerySingleOrDefaultAsync<OrderFormPaymentDto>(readCommand, parameters);
            return orderFormPayInfo;
        }

        public async Task<List<OrderFormWorkers>> GetOrderFormWorkerAsync(int orderFormId)
        {
            var query = @"
                    SELECT 
                        o.id AS OrderId,
                        o.creator_id AS CreatorId,
                        o.project_id AS ProjectId,
                        o.order_name AS OrderName,
                        o.order_description AS OrderDescription,
                        o.department_id AS DepartmentId,
                        o.created_at AS CreatedAt,
                        o.updated_at AS UpdatedAt,
                        ow.worker_type_id AS WorkerTypeId,
                        wt.worker_type_name AS WorkerTypeName,
                        ow.worker_team_id AS WorkerTeamId,
                        wtm.worker_team_name AS WorkerTeamName
                    FROM orderforms o
                    JOIN orderforms_workers ow ON o.id = ow.orderform_id
                    JOIN worker_types wt ON ow.worker_type_id = wt.worker_type_id
                    JOIN worker_teams wtm ON ow.worker_team_id = wtm.worker_team_id
                    WHERE o.id = @OrderFormId";
            var parameters = new { OrderFormId = orderFormId };
            var orderFormWithWorkers = await _dbConnection.QueryAsync<OrderFormWorkers>(query, parameters);
            return orderFormWithWorkers.ToList();
        }
    }
}