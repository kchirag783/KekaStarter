using InterviewApi.Models;
using System.ComponentModel.DataAnnotations;

namespace InterviewApi.Contracts.Requests
{
    public class IngestAlertRequest
    {
        [Required]
        public string ServiceId { get; set; } = string.Empty;

        [Required] public AlertSeverity Severity { get;set; }
        [Required] public string Title { get;set;} = string.Empty;

        [Required] public string Description { get;set; } = string.Empty;

        [Required] public string DedupeKey  { get;set ; } = string.Empty;

        public DateTimeOffset? TimeStamp { get; set; }
    }
}
