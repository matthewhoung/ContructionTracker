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
    }
}
