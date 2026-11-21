using InterviewApi.Models;

namespace InterviewApi.Services.Interfaces
{
    public interface IExotelService
    {
        Task<string> MakeCallAsync(string phoneNumenber, string message, CancellationToken cancellationToken);

    }
}
