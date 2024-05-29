using Application.DTOs;
using Application.Interfaces;
using Core.Entities.Forms.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/orderform")]
    [ApiController]
    public class OrderFormController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderFormController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpPost("create/form")]
        public async Task<IActionResult> CreateOrderFormAsync(OrderForm orderForm)
        {
            var createdOrderForm = await _orderServices.CreateOrderFormAsync(orderForm);
            return Ok(createdOrderForm);
        }

        [HttpPost("create/checklist")]
        public async Task<IActionResult> CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember)
        {
            await _orderServices.CreateOrderFormCheckList(orderFormCheckMember);
            return Ok(orderFormCheckMember);
        }

        [HttpPost("create/workerlist")]
        public async Task<IActionResult> CreateOrderFormWorkerList(OrderFromWorkerDto workerList)
        {
            var createdWorkerList = await _orderServices.CreateOrderFormWorkerList(workerList);
            return Ok(createdWorkerList);
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

        [HttpGet("get/orderformstatus/{orderFormId}")]
        public async Task<IActionResult> GetOrderFormStatusAsync(int orderFormId)
        {
            var orderFormStatus = await _orderServices.GetOrderFormStatusAsync(orderFormId);
            return Ok(orderFormStatus);
        }
        [HttpGet("get/orderformworker/{orderFormId}")]
        public async Task<IActionResult> GetOrderFormWorkerAsync(int orderFormId)
        {
            var orderFormWorkers = await _orderServices.GetOrderFormWorkerAsync(orderFormId);
            return Ok(orderFormWorkers);
        }
    }
}
