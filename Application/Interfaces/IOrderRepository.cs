using Core.Entities.Forms;
using Core.Entities.Forms.Orders;
using Core.Entities.Settings;

namespace Application.Application
{
    public interface IOrderRepository
    {
        Task<int> CreateOrderAsync(OrderForm order);
        Task<int> CreatOrderItemAsync(OrderItems orderItems);
        Task CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember);
        //後期改成個別狀態下的列表
        Task<List<OrderForm>> GetOrderAllAsync();
        Task<OrderForm> GetOrderByIdAsync(int orderFormId);
        Task<List<OrderFormStatus>> GetOrderFormStatusAsync(int orderFormId);
        Task<IReadOnlyList<PayBy>> GetPayByAsync();
        Task<IReadOnlyList<PayType>> GetPayTypesAsync();
        Task<IReadOnlyList<WorkerTeam>> GetWorkerTeamsAsync();
        Task<IReadOnlyList<WorkerType>> GetWorkerTypesAsync();
        Task<IReadOnlyList<WorkerClass>> GetWorkerClassesAsync();
    }
}
