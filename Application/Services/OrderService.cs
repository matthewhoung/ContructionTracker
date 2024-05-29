using Application.Application;
using Application.Interfaces;
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

        public async Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember)
        {
            await _orderRepository.CreateOrderFormCheckList(orderFormCheckMember);
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
        public async Task<List<OrderFormStatus>> GetOrderFormStatusAsync(int orderFormId)
        {
            var orderFormStatus = await _orderRepository.GetOrderFormStatusAsync(orderFormId);
            return orderFormStatus.ToList();
        }
    }
}
