using InterviewApi.Models;

namespace InterviewApi.Repositories.Interfaces
{
    public interface IIncidentRepository
    {
        Task<(Incident Incident, bool Created)> AddOrGetAsync(Incident Incident, CancellationToken cancellationToken);

        Task<List<Incident>> GetAllAsync(IncidentStatus? status, CancellationToken cancellationToken);

    }
}
