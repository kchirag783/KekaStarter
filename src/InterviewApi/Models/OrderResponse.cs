namespace InterviewApi.Models;

public record OrderResponse(Guid Id, string CustomerId, decimal Amount, string Currency, DateTime CreatedAt);
