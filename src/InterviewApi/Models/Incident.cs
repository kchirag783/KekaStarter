namespace InterviewApi.Models
{
    public class Incident
    {
        public string IncidentId { get; set; } = string.Empty;

        public string ServiceId { get; set; }  = string.Empty ;

        public string DedupeKey { get; set; } = string.Empty;

        public AlertSeverity Severity { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public IncidentStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string? Reason { get; set; }

        public Notification Notification { get; set; } = new();

    }
}
