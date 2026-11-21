using System.ComponentModel.DataAnnotations;

namespace InterviewApi.Models;

public record CreateOrderRequest(
    [Required] string CustomerId,
    [Range(0.01, double.MaxValue)] decimal Amount,
    [Required, StringLength(3, MinimumLength = 3)] string Currency);
