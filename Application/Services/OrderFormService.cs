using Application.Application;
using Application.DTOs;
using Application.Interfaces;
using Core.Entities.Forms;
using Core.Entities.Forms.Orders;
using Core.Entities.Settings;

namespace Application.Services
{
    public class OrderFormService : IOrderFormService
    {
        private readonly IOrderFormRepository _orderRepository;

        public OrderFormService(IOrderFormRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /*
         * Create Section
         */
        public async Task<int> CreateOrderFormAsync(OrderForm orderForm)
        {
            return await _orderRepository.CreateOrderAsync(orderForm);
        }
        public async Task<int> CreatOrderFormDetailAsync(OrderItems orderItems)
        {
            return await _orderRepository.CreatOrderDetailAsync(orderItems);
        }

        public async Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember)
        {
            await _orderRepository.CreateOrderFormCheckList(orderFormCheckMember);
        }

        public async Task<int> CreateOrderFormWorkerList(OrderFromWorkerDto workerList)
        {
            return await _orderRepository.CreateOrderFormWorkerList(workerList);
        }

        public Task<int> CreateOrderPayInfo(OrderFormPayInfo paymentInfo)
        {
            return _orderRepository.CreateOrderPayInfo(paymentInfo);
        }

        /*
         * Read Section
         */
        public async Task<List<OrderForm>> GetAllOrderFormAsync()
        {
            var orderForms = await _orderRepository.GetOrderAllAsync();
            return orderForms.ToList();
        }

        public async Task<OrderFormInfoDto> GetOrderFormAsync(int orderFormId)
        {
            var orderForm = await _orderRepository.GetOrderByIdAsync(orderFormId);
            if (orderForm == null) return null;

            var orderItems = await _orderRepository.GetOrderDetailAsync(orderFormId);
            var workers = await _orderRepository.GetOrderFormWorkerAsync(orderFormId);
            var payInfo = await _orderRepository.GetOrderFormPayInfoAsync(orderFormId);
            var signatures = await _orderRepository.GetOrderFormSignitureAsync(orderFormId);

            var orderformInfo = new OrderFormInfoDto
            {
                Id = orderForm.Id,
                CreatorId = orderForm.CreatorId,
                ProjectId = orderForm.ProjectId,
                OrderName = orderForm.OrderName,
                OrderDescription = orderForm.OrderDescription,
                Status = orderForm.Status,
                DepartmentId = orderForm.DepartmentId,
                OrderItems = orderItems,
                Workers = workers,
                PaymentInfo = payInfo,
                Signatures = signatures,
                CreatedAt = orderForm.CreatedAt,
                UpdatedAt = orderForm.UpdatedAt
            };

            return orderformInfo;
        }

        public async Task<List<OrderFormInfoDto>> GetOrderByUserAsync(int userId)
        {
            var orderforms = await _orderRepository.GetOrderByUserAsync(userId);
            if (orderforms == null || !orderforms.Any()) return null;

            var orderformInfos = await Task.WhenAll(
                orderforms.Select(order => GetOrderFormAsync(order.Id)));

            return orderformInfos.Where(info => info != null).ToList();
        }

        public async Task<List<OrderItems>> GetOrderDetailAsync(int orderFormId)
        {
            var orderDetails = await _orderRepository.GetOrderDetailAsync(orderFormId);
            return orderDetails.ToList();
        }

        public async Task<OrderFormPaymentDto> GetOrderFormPayInfoAsync(int orderFormId)
        {
            var orderFormPayInfo = await _orderRepository.GetOrderFormPayInfoAsync(orderFormId);
            return orderFormPayInfo;
        }

        public async Task<List<OrderFormStatus>> GetOrderFormSignitureAsync(int orderFormId)
        {
            var orderFormStatus = await _orderRepository.GetOrderFormSignitureAsync(orderFormId);
            return orderFormStatus.ToList();
        }

        public async Task<List<OrderFormWorkers>> GetOrderFormWorkerAsync(int orderFormId)
        {
            var orderFormWorkers = await _orderRepository.GetOrderFormWorkerAsync(orderFormId);
            return orderFormWorkers.ToList();
        }

        public async Task<Dictionary<string, int>> GetOrderFormStatusCountAsync()
        {
            var orderFormStatusCount = await _orderRepository.GetOrderFormStatusCountAsync();
            return orderFormStatusCount;
        }

        public async Task<int> GetOrderFormStatus(int orderfromId)
        {
            return await _orderRepository.GetOrderFormStatus(orderfromId);
        }

        /*
         * Update Section
         */
        public async Task UpdateStatusAsync(int orderFormId)
        {
            await _orderRepository.UpdateStatusAsync(orderFormId);
        }

        public async Task UpdateSignatureAsync(int orderFormId, int userId, bool isChecked)
        {
            await _orderRepository.UpdateSignatureAsync(orderFormId, userId, isChecked);
        }

        /*
         * Delete Section
         */

        public async Task DeleteOrderDetailAsync(int orderformId)
        {
            await _orderRepository.DeleteOrderDetailAsync(orderformId);
        }
    }
}
