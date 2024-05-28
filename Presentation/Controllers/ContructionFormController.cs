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

        [HttpPost("create/roles")]
        public async Task<IActionResult> CreateRolesAsync(Roles roles)
        {
            await _orderServices.CreateRolesAsync(roles);
            return Ok(roles);
        }

        [HttpPost("create/orderformcheckmember")]
        public async Task<IActionResult> CreateOrderFormCheckMember(OrderFormCheckMember orderFormCheckMember)
        {
            await _orderServices.CreateOrderFormCheckMember(orderFormCheckMember);
            return Ok(orderFormCheckMember);
        }

        [HttpGet("get/allorderform")]
        public async Task<IActionResult> GetAllOrderFormAsync()
        {
            var orderForms = await _orderServices.GetAllOrderFormAsync();
            return Ok(orderForms);
        }

        [HttpGet("get/orderform/{orderFormId}")]
        public async Task<IActionResult> GetOrderFormAsync(int orderFormId)
        {
            var orderForm = await _orderServices.GetOrderFormAsync(orderFormId);
            return Ok(orderForm);
        }
    }
}
