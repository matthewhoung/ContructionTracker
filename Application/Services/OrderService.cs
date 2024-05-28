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
        public async Task CreateDepartmentAsync(Department department)
        {
            await _orderRepository.CreateDepartmentAsync(department);
        }

        public async Task CreatePayByAsync(PayBy payBy)
        {
            await _orderRepository.CreatePayByAsync(payBy);
        }

        public async Task CreatePayTypeAsync(PayType payType)
        {
            await _orderRepository.CreatePayTypeAsync(payType);
        }

        public async Task CreateUnitAsync(UnitClass unitClass)
        {
            await _orderRepository.CreateUnitAsync(unitClass);
        }

        public async Task CreateRolesAsync(Roles roles)
        {
            await _orderRepository.CreateRolesAsync(roles);
        }

        public async Task CreateOrderFormCheckMember(OrderFormCheckMember orderFormCheckMember)
        {
            await _orderRepository.CreateOrderFormCheckMember(orderFormCheckMember);
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
    }
}
