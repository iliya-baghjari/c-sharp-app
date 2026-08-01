namespace GameStore.Api.Models;

// Represents a game available in the store.
public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Genre? Genre { get; set; }
    public int GenreId { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}