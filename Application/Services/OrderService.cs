using Application.Application;
using Application.Interfaces;
using Core.Entities.Forms;

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
    }
}
