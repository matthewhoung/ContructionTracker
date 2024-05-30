using Core.Entities.Settings.Generic;

namespace Application.Interfaces
{
    public interface IGenericService
    {
        Task CreateWorkerClassListAsync(WorkerClass workerClass);
        Task CreateWorkerTeamListAsync(WorkerTeam workerTeam);
        Task CreateWorkerTypeListAsync(WorkerType workerType);
        Task CreateDepartmentAsync(Department department);
        Task CreatePayByAsync(PayBy payBy);
        Task CreatePayTypeAsync(PayType payType);
        Task CreateUnitAsync(UnitClass unitClass);
        Task CreateRolesAsync(Roles roles);
    }
}
