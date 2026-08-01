namespace GameStore.Api.Models;

// Represents a category or genre for games.
public class Genre
{
    public int Id { get; set; }
    public required string Name { get; set; }
}