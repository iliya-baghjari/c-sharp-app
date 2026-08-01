
using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

// Build the web application and configure its services.
var builder = WebApplication.CreateBuilder(args);

// Configure the SQLite database for the game store context.
var conString = "Data Source=GameStore.db";
builder.Services.AddDbContext<GameStoreContext>(options =>
    options.UseSqlite(conString));

// Register validation services used by the application.
builder.Services.AddValidation();

// Create the application pipeline and map the API endpoints.
var app = builder.Build();
app.MapGamesEndpoints();

// Start the web host.
app.Run();

// Required for top-level statements and minimal hosting tests.
public partial class Program;
