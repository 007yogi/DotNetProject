using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderStore.Domain.Interfaces;

namespace UnityOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _IOrder;
        public OrderController(IOrder IOrder)
        {
            _IOrder = IOrder;
        }

        // GET: api/<Books>
        [HttpGet(nameof(GetOrders))]
        public async Task<IActionResult> GetOrders() {

            return Ok(await _IOrder.GetAll());
        }

        [HttpGet(nameof(GetOrderByName))]
        public async Task<IActionResult> GetOrderByName([FromQuery] string Genre) { 

            return Ok(await _IOrder.GetOrdersByOrderName(Genre));
        }
    }
}
