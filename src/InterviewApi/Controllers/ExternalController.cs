using InterviewApi.Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InterviewApi.Controllers;

// Quick check that the outbound HTTP client is wired up.
[ApiController]
[Route("api/external")]
public class ExternalController : ControllerBase
{
    private readonly IExternalApiClient _externalApiClient;

    public ExternalController(IExternalApiClient externalApiClient)
    {
        _externalApiClient = externalApiClient;
    }

    [HttpGet("todos/{id:int}")]
    public async Task<IActionResult> GetTodo(int id)
    {
        var todo = await _externalApiClient.GetTodoAsync(id);
        return todo == null ? NotFound() : Ok(todo);
    }
}
