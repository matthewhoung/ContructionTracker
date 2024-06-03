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
        private readonly IFileUploaderService _fileUploaderService;

        public OrderFormService(IOrderFormRepository orderRepository, IFileUploaderService fileUploaderService)
        {
            _orderRepository = orderRepository;
            _fileUploaderService = fileUploaderService;
        }

        /*
         * Create Section
         */
        public async Task<int> CreateOrderFormAsync(OrderForm orderForm)
        {
            return await _orderRepository.CreateOrderAsync(orderForm);
        }

        public async Task<List<OrderForm>> GetUserOrderFormAsync(int userId)
        {
            var orderForms = await _orderRepository.GetUserOrderFormAsync(userId);
            return orderForms;
        }


        public async Task<int> CreatOrderFormDetailAsync(OrderFormDetail orderItems)
        {
            return await _orderRepository.CreatOrderDetailAsync(orderItems);
        }

        public async Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember)
        {
            await _orderRepository.CreateOrderFormCheckList(orderFormCheckMember);
        }

        public async Task<int> CreateOrderFormWorkerList(OrderFormWorker workerList)
        {
            return await _orderRepository.CreateOrderFormWorkerList(workerList);
        }

        public Task<int> CreateOrderPayInfo(OrderFormPayInfo paymentInfo)
        {
            return _orderRepository.CreateOrderPayInfo(paymentInfo);
        }

        public async Task<int> CreatOrderFormDepartmentAsync(OrderFormDepartment department)
        {
            return await _orderRepository.CreatOrderFormDepartmentAsync(department);
        }

        /*
         * Read Section
         */
        public async Task<List<OrderForm>> GetAllOrderFormAsync()
        {
            var orderForms = await _orderRepository.GetOrderAllAsync();
            return orderForms;
        }

        public async Task<OrderFormInfoDto> GetOrderFormAsync(int orderFormId)
        {
            var orderForm = await _orderRepository.GetOrderByIdAsync(orderFormId);
            if (orderForm == null) return null;

            var orderItems = await _orderRepository.GetOrderDetailAsync(orderFormId);
            var workers = await _orderRepository.GetOrderFormWorkerAsync(orderFormId);
            var payInfo = await _orderRepository.GetOrderFormPayInfoAsync(orderFormId);
            var department = await _orderRepository.GetOrderFormDepartmentAsync(orderFormId);
            var filepaths = await _fileUploaderService.GetFilePathAsync(orderFormId);
            var signatures = await _orderRepository.GetOrderFormSignitureAsync(orderFormId);

            var orderformInfo = new OrderFormInfoDto
            {
                Id = orderForm.Id,
                CreatorId = orderForm.CreatorId,
                ProjectId = orderForm.ProjectId,
                OrderName = orderForm.OrderName,
                OrderDescription = orderForm.OrderDescription,
                Status = orderForm.Status,
                OrderItems = orderItems,
                Workers = workers,
                PaymentInfo = payInfo,
                Department = department,
                FilePaths = filepaths,
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

        public async Task<List<OrderFormDetail>> GetOrderDetailAsync(int orderFormId)
        {
            var orderDetails = await _orderRepository.GetOrderDetailAsync(orderFormId);
            return orderDetails;
        }

        public async Task<int> GetDetailTotalPriceAsync(int orderFormId)
        {
            var totalPrice = await _orderRepository.GetSumDetailTotalPriceAsync(orderFormId);
            return totalPrice;
        }

        public async Task<OrderFormPayInfo> GetOrderFormPayInfoAsync(int orderFormId)
        {
            var orderFormPayInfo = await _orderRepository.GetOrderFormPayInfoAsync(orderFormId);
            return orderFormPayInfo;
        }

        public async Task<List<OrderFormStatus>> GetOrderFormSignitureAsync(int orderFormId)
        {
            var orderFormStatus = await _orderRepository.GetOrderFormSignitureAsync(orderFormId);
            return orderFormStatus;
        }

        public async Task<List<OrderFormWorker>> GetOrderFormWorkerAsync(int orderFormId)
        {
            var orderFormWorkers = await _orderRepository.GetOrderFormWorkerAsync(orderFormId);
            return orderFormWorkers;
        }

        public async Task<Dictionary<string, int>> GetOrderFormStatusCountAsync()
        {
            var orderFormStatusCount = await _orderRepository.GetOrderFormStatusCountAsync();
            return orderFormStatusCount;
        }

        public async Task<string> GetOrderFormStatus(int orderfromId)
        {
            return await _orderRepository.GetOrderFormStatus(orderfromId);
        }

        public async Task<List<OrderFormDepartment>> GetOrderFormDepartmentAsync(int orderFormId)
        {
            var orderFormDepartments = await _orderRepository.GetOrderFormDepartmentAsync(orderFormId);
            return orderFormDepartments;
        }

        public async Task<List<OrderFormUnSignList>> GetUnSignFormsAsync()
        {
            var unSignForms = await _orderRepository.GetUnSignFormsAsync();
            return unSignForms;
        }

        /*
         * Update Section
         */

        public async Task UpdateOrderDetailAsync(OrderFormDetail orderItems)
        {
            await _orderRepository.UpdateOrderDetailAsync(orderItems);
        }

        public async Task UpdateOrderDetailTotalPriceAsync(int orderFormId)
        {
            await _orderRepository.UpdateOrderDetailTotalPriceAsync(orderFormId);
        }

        public async Task UpdateOrderFormPayInfoAsync(OrderFormPayInfo paymentInfo)
        {
            await _orderRepository.UpdateOrderFormPayInfoAsync(paymentInfo);
        }

        public async Task UpdateOrderFormPayinfoAmountAsync(int orderFormId)
        {
            await _orderRepository.UpdateOrderFormPayinfoAmountAsync(orderFormId);
        }

        public async Task UpdateWorkerAsync(OrderFormWorker workerList)
        {
            await _orderRepository.UpdateWorkerAsync(workerList);
        }

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
