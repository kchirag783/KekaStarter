using InterviewApi.Models;

namespace InterviewApi.Services.Interfaces;

public interface IOrderService
{
    Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request);
    Task<OrderResponse?> GetOrderAsync(Guid id);
}
