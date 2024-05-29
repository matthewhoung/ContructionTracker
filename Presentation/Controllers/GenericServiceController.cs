using Application.Interfaces;
using Core.Entities.Settings;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/generic")]
    [ApiController]
    public class GenericServiceController : ControllerBase
    {
        private readonly IGenericService _genericService;

        [HttpPost("create/workerclass")]
        public async Task<IActionResult> CreateWorkerClassListAsync(WorkerClass workerClass)
        {
            await _genericService.CreateWorkerClassListAsync(workerClass);
            return Ok(workerClass);
        }

        [HttpPost("create/workertype")]
        public async Task<IActionResult> CreateWorkerTypeListAsync(WorkerType workerType)
        {
            await _genericService.CreateWorkerTypeListAsync(workerType);
            return Ok(workerType);
        }

        [HttpPost("create/workerteam")]
        public async Task<IActionResult> CreateWorkerTeamListAsync(WorkerTeam workerTeam)
        {
            await _genericService.CreateWorkerTeamListAsync(workerTeam);
            return Ok(workerTeam);
        }

        [HttpPost("create/department")]
        public async Task<IActionResult> CreateDepartmentAsync(Department department)
        {
            await _genericService.CreateDepartmentAsync(department);
            return Ok(department);
        }

        [HttpPost("create/payby")]
        public async Task<IActionResult> CreatePayByAsync(PayBy payBy)
        {
            await _genericService.CreatePayByAsync(payBy);
            return Ok(payBy);
        }

        [HttpPost("create/paytype")]
        public async Task<IActionResult> CreatePayTypeAsync(PayType payType)
        {
            await _genericService.CreatePayTypeAsync(payType);
            return Ok(payType);
        }

        [HttpPost("create/unit")]
        public async Task<IActionResult> CreateUnitAsync(UnitClass unitClass)
        {
            await _genericService.CreateUnitAsync(unitClass);
            return Ok(unitClass);
        }

        [HttpPost("create/roles")]
        public async Task<IActionResult> CreateRolesAsync(Roles roles)
        {
            await _genericService.CreateRolesAsync(roles);
            return Ok(roles);
        }
    }
}
