using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;
using New_CRUDTask.Model.DTO;
using New_CRUDTask.ServiceImplementation;

namespace New_CRUDTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [Route("getall")]
        [HttpGet]
        public async Task<IActionResult> GetOrders(int page = 1, int pageSize = 10)
        {
            var orders = await _orderService.GetOrders(page, pageSize);
            return Ok(orders);
        }
        [Route("getbyid")]
        [HttpGet]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound(new { message = "Order not found" });
            }
            return Ok(order);
        }
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreatedDTO order)
        {
            var newOrder = await _orderService.CreateOrder(order);
            return Ok("Order placed successfully");
        }
        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(OrderCreatedDTO updatedOrder)
        {
            var result = await _orderService.UpdateOrder(updatedOrder);
            if (!result)
            {
                return NotFound(new { message = "Order not found" });
            }
            return Ok("Order placed successfully");
        }
        [Route("delete")]
        [HttpGet]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            if (!result)
            {
                return NotFound(new { message = "Order not found" });
            }
            return Ok("Order deleted successfully");
        }
    }
}
