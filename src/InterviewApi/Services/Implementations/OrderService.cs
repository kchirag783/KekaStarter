using InterviewApi.Models;
using InterviewApi.Repositories.Interfaces;
using InterviewApi.Services.Interfaces;

namespace InterviewApi.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<OrderService> _logger;

    public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = request.CustomerId,
            Amount = request.Amount,
            Currency = request.Currency.ToUpper(),
            CreatedAt = DateTime.UtcNow
        };

        await _orderRepository.AddAsync(order);
        _logger.LogInformation("Order {OrderId} created for customer {CustomerId}", order.Id, order.CustomerId);

        return ToResponse(order);
    }

    public async Task<OrderResponse?> GetOrderAsync(Guid id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        return order == null ? null : ToResponse(order);
    }

    private static OrderResponse ToResponse(Order order) =>
        new(order.Id, order.CustomerId, order.Amount, order.Currency, order.CreatedAt);
}
