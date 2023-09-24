using FinanceTracker.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationService(builder.Configuration);

var app = builder.Build();

app.MapControllers();

app.Run();
