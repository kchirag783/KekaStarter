using System.Collections.Concurrent;
using InterviewApi.Models;
using InterviewApi.Repositories.Interfaces;

namespace InterviewApi.Repositories.Implementations;

// In-memory for now; swap with a DB-backed implementation later.
public class InMemoryOrderRepository : IOrderRepository
{
    private readonly ConcurrentDictionary<Guid, Order> _orders = new();

    public Task AddAsync(Order order)
    {
        _orders[order.Id] = order;
        return Task.CompletedTask;
    }

    public Task<Order?> GetByIdAsync(Guid id)
    {
        _orders.TryGetValue(id, out var order);
        return Task.FromResult(order);
    }

    public Task<List<Order>> GetAllAsync()
    {
        return Task.FromResult(_orders.Values.ToList());
    }
}
