using CarbonTrace.API.Extensions;
using CarbonTrace.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

builder.Services.AddCarbonTraceDbContext(builder.Configuration);

builder.Services.AddCarbonTraceRepositories();

builder.Services.AddCarbonTraceApplicationServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Aplica migrations automaticamente ao iniciar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CarbonTraceContext>();
    db.Database.Migrate();
}

app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "PetPulse API v1");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();