using InterviewApi.Clients.Implementations;
using InterviewApi.Clients.Interfaces;
using InterviewApi.Repositories.Implementations;
using InterviewApi.Repositories.Interfaces;
using InterviewApi.Services.Implementations;
using InterviewApi.Services.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddHttpClient<IExternalApiClient, ExternalApiClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ExternalApi:BaseUrl"]!);
})
.AddStandardResilienceHandler();

var app = builder.Build();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
