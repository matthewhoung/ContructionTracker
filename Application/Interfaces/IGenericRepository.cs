using Core.Entities.Settings.Generic;

namespace Application.Interfaces
{
    public interface IGenericRepository
    {
        //TODO:
        /* 
         * 新增創建功能:
         * 新增取得功能: payinfo[paymentAmount]計算稅賦金額、議價、折讓扣
         * 新增更新功能: 
         * 新增刪除功能: 
         */
        Task CreateWorkerClassAsync(WorkerClass workerClass);
        Task CreateWorkerTypeAsync(WorkerType workerType);
        Task CreateWorkerTeamAsync(WorkerTeam workerTeam);
        Task CreateDepartmentAsync(Department department);
        Task CreatePayByAsync(PayBy payBy);
        Task CreatePayTypeAsync(PayType payType);
        Task CreateUnitAsync(UnitClass unitClass);
        Task CreateRolesAsync(Roles roles);
    }
}
