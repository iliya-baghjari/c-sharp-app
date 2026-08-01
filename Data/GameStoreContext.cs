using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

// EF Core database context for the game store.
public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    // Represents the collection of games stored in the database.
    public DbSet<Game> Games => Set<Game>();

    // Represents the collection of genres available for games.
    public DbSet<Genre> Genres => Set<Genre>();
}