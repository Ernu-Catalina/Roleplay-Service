using RoleplayService;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Create an instance of the in-memory repository
var repository = new RoleplayRepository();

app.MapGet("/", () => "Roleplay Service is running!");

// Endpoint to list all role actions
app.MapGet("/api/roleplay/actions", () => repository.GetActions());

// Endpoint to add a new action
app.MapPost("/api/roleplay/actions", (RoleAction action) =>
{
    repository.AddAction(action);
    return Results.Created($"/api/roleplay/actions/{action.Id}", action);
});

app.Run();
