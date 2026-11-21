namespace InterviewApi.Clients.Models;

public record TodoItem(int Id, int UserId, string Title, bool Completed);
