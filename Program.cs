using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddValidation();
app.MapGamesEndpoints();

app.Run();
