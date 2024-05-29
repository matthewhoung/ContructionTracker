using Core.Entities.Settings;

namespace Application.Interfaces
{
    public interface IGenericRepository
    {
        Task CreateWorkerClassAsync(WorkerClass workerClass);
        Task CreateWorkerTypeAsync(WorkerType workerType);
        Task CreateWorkerTeamAsync(WorkerTeam workerTeam);
        Task CreateDepartmentAsync(Department department);
        Task CreateUnitAsync(UnitClass unitClass);
        Task CreatePayTypeAsync(PayType payType);
        Task CreatePayByAsync(PayBy payBy);
        Task CreateRolesAsync(Roles roles);
    }
}
