using Application.Interfaces;
using Core.Entities.Settings.Generic;

namespace Application.Services
{
    public class GenericService : IGenericService
    {
        private readonly IGenericRepository _genericRepository;
        
        public GenericService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task CreateWorkerClassListAsync(WorkerClass workerClass)
        {
            await _genericRepository.CreateWorkerClassAsync(workerClass);
        }

        public async Task CreateWorkerTeamListAsync(WorkerTeam workerTeam)
        {
            await _genericRepository.CreateWorkerTeamAsync(workerTeam);
        }

        public async Task CreateWorkerTypeListAsync(WorkerType workerType)
        {
            await _genericRepository.CreateWorkerTypeAsync(workerType);
        }
        public async Task CreateDepartmentAsync(Department department)
        {
            await _genericRepository.CreateDepartmentAsync(department);
        }

        public async Task CreatePayByAsync(PayBy payBy)
        {
            await _genericRepository.CreatePayByAsync(payBy);
        }

        public async Task CreatePayTypeAsync(PayType payType)
        {
            await _genericRepository.CreatePayTypeAsync(payType);
        }

        public async Task CreateUnitAsync(UnitClass unitClass)
        {
            await _genericRepository.CreateUnitAsync(unitClass);
        }

        public async Task CreateRolesAsync(Roles roles)
        {
            await _genericRepository.CreateRolesAsync(roles);
        }
    }
}
