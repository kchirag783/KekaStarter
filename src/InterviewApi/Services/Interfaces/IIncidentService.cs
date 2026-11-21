using InterviewApi.Models;

namespace InterviewApi.Services.Interfaces
{
    public interface IIncidentService
    {
        Task<List<Incident>> GetAllAsync(IncidentStatus? status, CancellationToken cancellationToken);
    }
}
