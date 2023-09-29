using FinanceTracker.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEverything(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
