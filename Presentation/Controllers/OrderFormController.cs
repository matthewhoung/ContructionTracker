using Application.DTOs;
using Application.Interfaces;
using Core.Entities.Forms;
using Core.Entities.Forms.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/orderform")]
    [ApiController]
    public class OrderFormController : ControllerBase
    {
        private readonly IOrderFormService _orderServices;
        public OrderFormController(IOrderFormService orderServices)
        {
            _orderServices = orderServices;
        }

        /*
         * POST Section
         */

        [HttpPost("create/form")]
        public async Task<IActionResult> CreateOrderFormAsync(OrderForm orderForm)
        {
            var createdOrderForm = await _orderServices.CreateOrderFormAsync(orderForm);
            return Ok(createdOrderForm);
        }
        [HttpPost("create/form/detail")]
        public async Task<IActionResult> CreateOrderFormDetailAsync(OrderItems orderItems)
        {
            var createdOrderDetail = await _orderServices.CreatOrderFormDetailAsync(orderItems);
            return Ok(createdOrderDetail);
        }

        [HttpPost("create/form/payinfo")]
        public async Task<IActionResult> CreateOrderPayInfo(OrderFormPayInfo paymentInfo)
        {
            var createdPaymentInfo = await _orderServices.CreateOrderPayInfo(paymentInfo);
            return Ok(createdPaymentInfo);
        }

        [HttpPost("create/form/checklist")]
        public async Task<IActionResult> CreateOrderFormCheckList(OrderFormCheckList orderFormCheckMember)
        {
            await _orderServices.CreateOrderFormCheckList(orderFormCheckMember);
            return Ok(orderFormCheckMember);
        }

        [HttpPost("create/form/workerlist")]
        public async Task<IActionResult> CreateOrderFormWorkerList(OrderFromWorkerDto workerList)
        {
            var createdWorkerList = await _orderServices.CreateOrderFormWorkerList(workerList);
            return Ok(createdWorkerList);
        }

        /*
         * GET Section
         */

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

        [HttpGet("get/orderform/detail/{orderFormId}")]
        public async Task<IActionResult> GetOrderDetailAsync(int orderFormId)
        {
            var orderDetails = await _orderServices.GetOrderDetailAsync(orderFormId);
            return Ok(orderDetails);
        }

        [HttpGet("get/orderform/payinfo/{orderFormId}")]
        public async Task<IActionResult> GetOrderFormPayInfoAsync(int orderFormId)
        {
            var orderFormPayInfo = await _orderServices.GetOrderFormPayInfoAsync(orderFormId);
            return Ok(orderFormPayInfo);
        }

        [HttpGet("get/orderform/signiture/{orderFormId}")]
        public async Task<IActionResult> GetOrderFormSignitureAsync(int orderFormId)
        {
            var orderFormStatus = await _orderServices.GetOrderFormSignitureAsync(orderFormId);
            return Ok(orderFormStatus);
        }
        [HttpGet("get/orderform/worker/{orderFormId}")]
        public async Task<IActionResult> GetOrderFormWorkerAsync(int orderFormId)
        {
            var orderFormWorkers = await _orderServices.GetOrderFormWorkerAsync(orderFormId);
            return Ok(orderFormWorkers);
        }

        [HttpGet("get/orderform/statuscount")]
        public async Task<IActionResult> GetOrderFormStatusCountAsync()
        {
            var orderFormStatusCount = await _orderServices.GetOrderFormStatusCountAsync();
            return Ok(orderFormStatusCount);
        }

        [HttpGet("get/orderform/status/{orderfromId}")]
        public async Task<IActionResult> GetOrderFormStatus(int orderfromId)
        {
            var orderFormStatus = await _orderServices.GetOrderFormStatus(orderfromId);
            return Ok(orderFormStatus);
        }

        /*
         * PUT Section
         */

        [HttpPut("update/status/{orderFormId}")]
        public async Task<IActionResult> UpdateStatusAsync(int orderFormId)
        {
            await _orderServices.UpdateStatusAsync(orderFormId);
            return Ok();
        }

        [HttpPut("update/ischecked/{orderFormId}/{userId}/{isChecked}")]
        public async Task<IActionResult> UpdateSignatureAsync(int orderFormId, int userId, bool isChecked)
        {
            await _orderServices.UpdateSignatureAsync(orderFormId, userId, isChecked);
            return Ok();
        }

        /*
         * DELETE Section
         */

        [HttpDelete("delete/orderform/detail/{orderformId}")]
        public async Task<IActionResult> DeleteOrderDetailAsync(int orderformId)
        {
            await _orderServices.DeleteOrderDetailAsync(orderformId);
            return Ok();
        }
    }
}
