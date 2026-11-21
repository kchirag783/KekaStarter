using System.Net;
using InterviewApi.Clients.Interfaces;
using InterviewApi.Clients.Models;

namespace InterviewApi.Clients.Implementations;

public class ExternalApiClient : IExternalApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ExternalApiClient> _logger;

    public ExternalApiClient(HttpClient httpClient, ILogger<ExternalApiClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<TodoItem?> GetTodoAsync(int id)
    {
        _logger.LogInformation("Fetching todo {TodoId} from external API", id);

        var response = await _httpClient.GetAsync($"todos/{id}");

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TodoItem>();
    }
}
