namespace InterviewApi.Models
{
    public class Alert
    {
        public Guid Id { get; set; }

        public Guid RuleId { get; set; }

        public AlertSeverity Severity { get; set; }

        public string Message { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
