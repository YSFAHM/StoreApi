using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entities;
using Store.Service.HandleResponses;
using Store.Service.Services.OrderService;
using Store.Service.Services.OrderService.Dtos;
using System.Security.Claims;

namespace Store.Web.Controllers
{

    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDetailsDto>> CreateOrderAsync(OrderDto input)
        {
            var order = await _orderService.CreateOrderAsync(input);
            if (order is null)
                return BadRequest(new Response(400, "Error While Placing Your Order"));
            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDetailsDto>>> GetAllOrdersForUserAsync()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var orders = await _orderService.GetAllOrdersForUserAsync(userEmail);
            return Ok(orders);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDetailsDto>> GetOrderByIdAsync (Guid id)
        {
            return Ok(await _orderService.GetOrderByIdAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetAllDeliveryMethodsAsync()
        {
            return Ok(await _orderService.GetAllDeliveryMethodAsync());
        }
    }
}
