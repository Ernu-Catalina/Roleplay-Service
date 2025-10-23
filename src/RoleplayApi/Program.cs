using StackExchange.Redis;
using ServiceRegistration; // includes ServiceRegistration, CacheService, RoleLogicService
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// ---------------------- Redis ----------------------
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var config = builder.Configuration["Redis:Config"] ?? "localhost:6379";
    return ConnectionMultiplexer.Connect(config);
});
builder.Services.AddSingleton<CacheService>();

// ---------------------- Role Logic Service ----------------------
builder.Services.AddHttpClient<RoleLogicService>();
builder.Services.AddScoped<RoleLogicService>();

// ---------------------- Controllers + Swagger ----------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------------------- Service Registration ----------------------
// Ensure ServiceRegistration implements IHostedService
builder.Services.AddHttpClient();
builder.Services.AddHostedService<ServiceRegistration>();

var app = builder.Build();

// ---------------------- Middleware ----------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// ---------------------- Health Check ----------------------
app.MapGet("/health", () =>
{
    var ts = DateTime.UtcNow;
    Console.WriteLine($"[HEALTH] Health check requested at {ts:O}");
    return Results.Json(new
    {
        status = "healthy",
        service = "roleplay-service",
        timestamp = ts
    });
});

app.Run();
