using Core.Entities.Enums;
using Core.Entities.Forms;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderForm> GetOrderAllAsync();
        Task<OrderForm> GetOrderByIdAsync(int id);
        Task<int> CreateOrderAsync(OrderForm order);
        Task<int> CreateReceiverAsync(ReceiveForm receiver);
        Task<int> CreatePayableAsync(PayableForm payable);
        //下列將會在database進行indexing
        Task<IReadOnlyList<WorkerType>> GetWorkerTypesAsync();
        Task<IReadOnlyList<WorkerTeam>> GetWorkerTeamsAsync();
        Task<IReadOnlyList<Department>> GetDepartmentsAsync();
        Task<IReadOnlyList<PayType>> GetPayTypesAsync();
    }
}
