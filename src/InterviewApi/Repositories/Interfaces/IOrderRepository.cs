using InterviewApi.Models;

namespace InterviewApi.Repositories.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<Order?> GetByIdAsync(Guid id);
    Task<List<Order>> GetAllAsync();
}
