using Core.Entities.Forms;
using Core.Entities.Settings;

namespace Application.Application
{
    public interface IOrderRepository
    {
        Task<int> CreateOrderAsync(OrderForm order);
        Task<int> CreatOrderItemAsync(OrderItems orderItems);
        Task CreateWorkerClassAsync(WorkerClass workerClass);
        Task CreateWorkerTypeAsync(WorkerType workerType);
        Task CreateWorkerTeamAsync(WorkerTeam workerTeam);
        Task CreateDepartmentAsync(int departmentId, string departmentName);
        Task CreateUnitAsync(int unitId, string unitName);
        Task CreatePayTypeAsync(int payTypeId, string payTypeName);
        Task CreatePayByAsync(int payById, string payByName);
        Task<OrderForm> GetOrderAllAsync();
        Task<OrderForm> GetOrderByIdAsync(int id);
        Task<IReadOnlyList<PayBy>> GetPayByAsync();
        Task<IReadOnlyList<PayType>> GetPayTypesAsync();
        Task<IReadOnlyList<WorkerTeam>> GetWorkerTeamsAsync();
        Task<IReadOnlyList<WorkerType>> GetWorkerTypesAsync();
    }
}
