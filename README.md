# InterviewApi

ASP.NET Core 9 Web API starter.

- Serilog for logging
- Typed `HttpClient` (with retry/timeout via `Microsoft.Extensions.Http.Resilience`) for outbound calls
- In-memory repository behind an interface, so it can be swapped for a database later

## Run

```
dotnet run --project src/InterviewApi --launch-profile http
```

Requests to try are in `src/InterviewApi/InterviewApi.http`.
