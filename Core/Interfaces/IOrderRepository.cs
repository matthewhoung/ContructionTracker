using Core.Entities;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderForm> GetOrderAllAsync();
        Task<OrderForm> GetOrderByIdAsync(int id);
        Task<int> CreateOrderAsync(OrderForm order);
        Task<IReadOnlyList<WorkerType>> GetWorkerTypesAsync();
        Task<IReadOnlyList<WorkerTeam>> GetWorkerTeamsAsync();
        Task<IReadOnlyList<Department>> GetDepartmentsAsync();
        Task<IReadOnlyList<PayType>> GetPayTypesAsync();
    }
}
