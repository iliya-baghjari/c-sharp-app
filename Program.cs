
using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conString = "Data Source=GameStore.db";
builder.Services.AddDbContext<GameStoreContext>(options =>
    options.UseSqlite(conString));

builder.Services.AddValidation();

var app = builder.Build();
app.MapGamesEndpoints();

app.Run();

public partial class Program;
