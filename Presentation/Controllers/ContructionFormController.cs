using Application.Interfaces;
using Core.Entities.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContructionFormController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public ContructionFormController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderFormAsync(OrderForm orderForm)
        {
            var result = await _orderServices.CreateOrderFormAsync(orderForm);
            return Ok(result);
        }
    }
}
