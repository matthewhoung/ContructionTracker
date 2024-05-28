using Application.Interfaces;
using Core.Entities.Forms;
using Core.Entities.Settings;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/budget")]
    [ApiController]
    public class ContructionFormController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public ContructionFormController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpPost("create/orderform")]
        public async Task<IActionResult> CreateOrderFormAsync(OrderForm orderForm)
        {
            var createdOrderForm = await _orderServices.CreateOrderFormAsync(orderForm);
            return Ok(createdOrderForm);
        }

        [HttpPost("create/workerclass")]
        public async Task<IActionResult> CreateWorkerClassListAsync(WorkerClass workerClass)
        {
            await _orderServices.CreateWorkerClassListAsync(workerClass);
            return Ok(workerClass);
        }

        [HttpPost("create/workertype")]
        public async Task<IActionResult> CreateWorkerTypeListAsync(WorkerType workerType)
        {
            await _orderServices.CreateWorkerTypeListAsync(workerType);
            return Ok(workerType);
        }

        [HttpPost("create/workerteam")]
        public async Task<IActionResult> CreateWorkerTeamListAsync(WorkerTeam workerTeam)
        {
            await _orderServices.CreateWorkerTeamListAsync(workerTeam);
            return Ok(workerTeam);
        }

        [HttpPost("create/department")]
        public async Task<IActionResult> CreateDepartmentAsync(Department department)
        {
            await _orderServices.CreateDepartmentAsync(department);
            return Ok(department);
        }

        [HttpPost("create/payby")]
        public async Task<IActionResult> CreatePayByAsync(PayBy payBy)
        {
            await _orderServices.CreatePayByAsync(payBy);
            return Ok(payBy);
        }

        [HttpPost("create/paytype")]
        public async Task<IActionResult> CreatePayTypeAsync(PayType payType)
        {
            await _orderServices.CreatePayTypeAsync(payType);
            return Ok(payType);
        }

        [HttpPost("create/unit")]
        public async Task<IActionResult> CreateUnitAsync(UnitClass unitClass)
        {
            await _orderServices.CreateUnitAsync(unitClass);
            return Ok(unitClass);
        }
    }
}
