namespace  GameStore.Api.Endpoints;

public static class GamesEndpoints
{
   const string endpointGame = "GetGame";
    private static readonly List<Dtos.GameDto> games =[
        
            new(1, "Game 1", "Genre 1", 19.99m, DateOnly.FromDateTime(DateTime.Today)),
            new(2, "Game 2", "Genre 2", 29.99m, DateOnly.FromDateTime(DateTime.Today))
        ];

    public static void MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games").WithTags("Games");
       
group.MapGet("/", () => games);

//get game 1
group.MapGet("/{id}", (int id) =>
{
   var game = games.Find(g => g.Id == id);
   return game is not null ? Results.Ok(game) : Results.NotFound();
}).WithName(endpointGame);
    


//post /games
group.MapPost("/", (Dtos.CreateGameDto newGame) =>
{
    Dtos.GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );

    games.Add(game);
    return Results.CreatedAtRoute(endpointGame, new { id = game.Id }, game);
});


// PUT /games/{id}
group.MapPut("/{id}", (int id, Dtos.UpdateGameDto updatedGame) =>
{
    var game = games.Find(g => g.Id == id);
    if (game is null) return Results.NotFound();

    var index = games.IndexOf(game);
     games[index]= new Dtos.GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );

  
    return Results.NoContent();
});

// DELETE /games/{id}
group.MapDelete("/{id}", (int id) =>    
{
    var game = games.Find(g => g.Id == id);
    if (game is null) return Results.NotFound();

    games.Remove(game);
    return Results.NoContent();
});

}}