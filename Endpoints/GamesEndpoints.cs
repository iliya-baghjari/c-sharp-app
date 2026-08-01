namespace GameStore.Api.Endpoints;

// Defines the HTTP endpoints for managing games in the API.
public static class GamesEndpoints
{
    // Route name used for CreatedAtRoute responses.
    private const string EndpointGame = "GetGame";

    // In-memory sample data for the API during development.
    private static readonly List<Dtos.GameDto> Games =
    [
        new(1, "Game 1", "Genre 1", 19.99m, DateOnly.FromDateTime(DateTime.Today)),
        new(2, "Game 2", "Genre 2", 29.99m, DateOnly.FromDateTime(DateTime.Today))
    ];

    // Maps all game-related endpoints under the /games route group.
    public static void MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games").WithTags("Games");

        // Get all games.
        group.MapGet("/", () => Games);

        // Get a single game by id.
        group.MapGet("/{id}", (int id) =>
        {
            var game = Games.Find(g => g.Id == id);
            return game is not null ? Results.Ok(game) : Results.NotFound();
        }).WithName(EndpointGame);

        // Create a new game.
        group.MapPost("/", (Dtos.CreateGameDto newGame) =>
        {
            var game = new Dtos.GameDto(
                Games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );

            Games.Add(game);
            return Results.CreatedAtRoute(EndpointGame, new { id = game.Id }, game);
        });

        // Update an existing game.
        group.MapPut("/{id}", (int id, Dtos.UpdateGameDto updatedGame) =>
        {
            var game = Games.Find(g => g.Id == id);
            if (game is null) return Results.NotFound();

            var index = Games.IndexOf(game);
            Games[index] = new Dtos.GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();
        });

        // Delete a game by id.
        group.MapDelete("/{id}", (int id) =>
        {
            var game = Games.Find(g => g.Id == id);
            if (game is null) return Results.NotFound();

            Games.Remove(game);
            return Results.NoContent();
        });
    }
}