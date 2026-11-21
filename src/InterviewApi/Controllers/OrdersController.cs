using InterviewApi.Models;
using InterviewApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InterviewApi.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<ActionResult<OrderResponse>> Create(CreateOrderRequest request)
    {
        var order = await _orderService.CreateOrderAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderResponse>> GetById(Guid id)
    {
        var order = await _orderService.GetOrderAsync(id);
        return order == null ? NotFound() : Ok(order);
    }
}
