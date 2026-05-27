using CarbonTrace.API.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarbonTraceDbContext(builder.Configuration);
builder.Services.AddCarbonTraceRepositories();
builder.Services.AddCarbonTraceApplicationServices();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCarbonTraceSwagger(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "CarbonTrace API v1");
        options.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();