using Application.Interfaces;
using Core.Entities.Forms;
using Core.Entities.Settings;
using Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            try
            {
                var createdOrderForm = await _orderServices.CreateOrderFormAsync(orderForm);
                return ResponseStandardConfiguration.StandardizeResponse("Order Form Created", HttpStatusCode.Created, "201", createdOrderForm);
            }
            catch (Exception ex)
            {
                return ResponseStandardConfiguration.HandleException(ex);
            }
        }

        [HttpPost("create/workerclass")]
        public async Task<IActionResult> CreateWorkerClassListAsync(WorkerClass workerClass)
        {
            await _orderServices.CreateWorkerClassListAsync(workerClass);
            return ResponseStandardConfiguration.StandardizeResponse("Worker Class Created", HttpStatusCode.Created, "201", workerClass);
        }

        [HttpPost("create/workertype")]
        public async Task<IActionResult> CreateWorkerTypeListAsync(WorkerType workerType)
        {
            await _orderServices.CreateWorkerTypeListAsync(workerType);
            return ResponseStandardConfiguration.StandardizeResponse("Worker Type Created", HttpStatusCode.Created, "201", workerType);
        }

        [HttpPost("create/workerteam")]
        public async Task<IActionResult> CreateWorkerTeamListAsync(WorkerTeam workerTeam)
        {
            await _orderServices.CreateWorkerTeamListAsync(workerTeam);
            return ResponseStandardConfiguration.StandardizeResponse("Worker Team Created", HttpStatusCode.Created, "201", workerTeam);
        }

        [HttpPost("create/department")]
        public async Task<IActionResult> CreateDepartmentAsync(Department department)
        {
            await _orderServices.CreateDepartmentAsync(department);
            return ResponseStandardConfiguration.StandardizeResponse("Department Created", HttpStatusCode.Created, "201", department);
        }

        [HttpPost("create/payby")]
        public async Task<IActionResult> CreatePayByAsync(PayBy payBy)
        {
            await _orderServices.CreatePayByAsync(payBy);
            return ResponseStandardConfiguration.StandardizeResponse("Pay By Created", HttpStatusCode.Created, "201", payBy);
        }

        [HttpPost("create/paytype")]
        public async Task<IActionResult> CreatePayTypeAsync(PayType payType)
        {
            await _orderServices.CreatePayTypeAsync(payType);
            return ResponseStandardConfiguration.StandardizeResponse("Pay Type Created", HttpStatusCode.Created, "201", payType);
        }

        [HttpPost("create/unit")]
        public async Task<IActionResult> CreateUnitAsync(UnitClass unitClass)
        {
            await _orderServices.CreateUnitAsync(unitClass);
            return ResponseStandardConfiguration.StandardizeResponse("Unit Created", HttpStatusCode.Created, "201", unitClass);
        }
    }
}
