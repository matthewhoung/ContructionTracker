using Core.Entities.Forms;
using Core.Entities.Settings;

namespace Application.Application
{
    public interface IOrderRepository
    {
        Task<int> CreateOrderAsync(OrderForm order);
        Task<int> CreatOrderItemAsync(OrderItems orderItems);
        Task<OrderForm> GetOrderAllAsync();
        Task<OrderForm> GetOrderByIdAsync(int id);
        Task<IReadOnlyList<PayBy>> GetPayByAsync();
        Task<IReadOnlyList<PayType>> GetPayTypesAsync();
        Task<IReadOnlyList<WorkerTeam>> GetWorkerTeamsAsync();
        Task<IReadOnlyList<WorkerType>> GetWorkerTypesAsync();
    }
}
