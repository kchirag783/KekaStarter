using InterviewApi.Contracts.Requests;
using InterviewApi.Models;

namespace InterviewApi.Services.Interfaces
{
    public interface IAlertService
    {
        Task<Incident> IngestAsync(IngestAlertRequest request, CancellationToken cancellationToken);

    }
}
