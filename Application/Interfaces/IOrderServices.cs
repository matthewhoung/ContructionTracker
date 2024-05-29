using Core.Entities.Forms;
using Core.Entities.Settings;

namespace Application.Interfaces
{
    public interface IOrderServices
    {
        Task<int> CreateOrderFormAsync(OrderForm orderForm);
        Task CreateWorkerClassListAsync(WorkerClass workerClass);
        Task CreateWorkerTypeListAsync(WorkerType workerType);
        Task CreateWorkerTeamListAsync(WorkerTeam workerTeam);
        Task CreateDepartmentAsync(Department department);
        Task CreatePayByAsync(PayBy payBy);
        Task CreatePayTypeAsync(PayType payType);
        Task CreateUnitAsync(UnitClass unitClass);
        Task CreateRolesAsync(Roles roles);
        Task CreateOrderFormCheckMember(OrderFormCheckMember orderFormCheckMember);
        Task<List<OrderForm>> GetAllOrderFormAsync();
        Task<OrderForm> GetOrderFormAsync(int orderFormId);
        Task<List<OrderFormStatus>> GetOrderFormStatusAsync(int orderFormId);
    }
}
