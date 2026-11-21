namespace InterviewApi.Models
{
    public class Notification
    {
        public NotificationChannel Channel { get; set; } = NotificationChannel.PHONE;
        public string? ProviderCallId { get; set; }

        public string? LastError { get; set; }

        public NotificationStatus Status { get; set; } = NotificationStatus.Skipped;
    }
}
