namespace InterviewApi.Models;

public class Order
{
    public Guid Id { get; set; }
    public string CustomerId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
