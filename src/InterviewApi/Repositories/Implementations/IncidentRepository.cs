using InterviewApi.Models;
using InterviewApi.Repositories.Interfaces;

namespace InterviewApi.Repositories.Implementations
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly IIncidentRepository _incidentRepository;

        private readonly Dictionary<string,Incident> _incidents = new();


        private readonly object _lock = new();

        Task<(Incident Incident, bool Created)> AddOrGetAsync(Incident Incident, CancellationToken cancellationToken)
        {
            var key = CreateKey(Incident.ServiceId, Incident.DedupeKey);

            lock (_lock)
            {
                if (_incidents.TryGetValue(key, out var existing))
                {
                    return Task.FromResult(existing, false);
                }
                _incidents[key] = Incident;

                return Task.FromResult(Incident, true);
            }
        }

        private static string CreateKey(string serviceId, string key)
        {
            return $"{serviceId}.{key}";
        }


        Task<List<Incident>> GetAllAsync(IncidentStatus? status, CancellationToken cancellationToken)
        {
            lock (_lock)
            {
                var incidents = new _incidents.Values().Where(x => status == null || x.status == status)
                    .OrderByDescending(x => x.CreatedAt).ToList();

            }

        }
    }
