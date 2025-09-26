using Microsoft.EntityFrameworkCore;
using RoleplayService;
using RoleplayService.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetValue<string>("POSTGRES_CONNECTION")
                       ?? "Host=postgres-roleplay;Port=5432;Database=roleplaydb;Username=roleplayuser;Password=roleplaypass";

builder.Services.AddDbContext<RoleplayDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RoleplayDbContext>();
    db.Database.Migrate(); // ensures tables exist
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
