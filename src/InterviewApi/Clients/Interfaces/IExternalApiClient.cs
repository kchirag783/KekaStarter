using InterviewApi.Clients.Models;

namespace InterviewApi.Clients.Interfaces;

public interface IExternalApiClient
{
    Task<TodoItem?> GetTodoAsync(int id);
}
