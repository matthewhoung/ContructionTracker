using Application.Application;
using Application.Interfaces;
using Core.Entities.Forms;
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

        public async Task CreateWorkerClassListAsync(WorkerClass workerClass)
        {
            await _orderRepository.CreateWorkerClassAsync(workerClass);
        }

        public async Task CreateWorkerTeamListAsync(WorkerTeam workerTeam)
        {
            await _orderRepository.CreateWorkerTeamAsync(workerTeam);
        }

        public async Task CreateWorkerTypeListAsync(WorkerType workerType)
        {
            await _orderRepository.CreateWorkerTypeAsync(workerType);
        }
    }
}
