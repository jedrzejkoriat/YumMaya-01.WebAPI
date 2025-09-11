using Microsoft.Extensions.Logging;
using YumMaya_01.WebAPI.API.Configuration;
using YumMaya_01.WebAPI.Application.Configuration;
using YumMaya_01.WebAPI.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSqliteConnection(builder.Configuration);
builder.Services.AddEfCoreRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddApplicationMapper();
builder.Services.AddDtoValidation();
builder.Services.AddUnitOfWork();
builder.Services.AddRequestLimiter();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.AddLogger();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();

try
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    logger.LogInformation("Application starting...");

    app.Run();

    logger.LogInformation("Application started successfully.");
}
catch (Exception ex)
{
    logger.LogCritical(ex, "Application failed to start.");
    throw;
}