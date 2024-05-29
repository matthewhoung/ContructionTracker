using Application.Application;
using Application.DTOs;
using Application.Interfaces;
using Core.Entities.Forms;
using Core.Entities.Forms.Orders;
using Core.Entities.Settings;

namespace Application.Services
{
    public class OrderService : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
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

        public async Task<List<OrderForm>> GetAllOrderFormAsync()
        {
            var orderForms = await _orderRepository.GetOrderAllAsync();
            return orderForms.ToList();
        }

        public async Task<OrderForm> GetOrderFormAsync(int orderFormId)
        {
            var orderForm = await _orderRepository.GetOrderByIdAsync(orderFormId);
            return orderForm;
        }

        public async Task<OrderFormPaymentDto> GetOrderFormPayInfoAsync(int orderFormId)
        {
            var orderFormPayInfo = await _orderRepository.GetOrderFormPayInfoAsync(orderFormId);
            return orderFormPayInfo;
        }

        public async Task<List<OrderFormStatus>> GetOrderFormStatusAsync(int orderFormId)
        {
            var orderFormStatus = await _orderRepository.GetOrderFormStatusAsync(orderFormId);
            return orderFormStatus.ToList();
        }

        public async Task<List<OrderFormWorkers>> GetOrderFormWorkerAsync(int orderFormId)
        {
            var orderFormWorkers = await _orderRepository.GetOrderFormWorkerAsync(orderFormId);
            return orderFormWorkers.ToList();
        }
    }
}
