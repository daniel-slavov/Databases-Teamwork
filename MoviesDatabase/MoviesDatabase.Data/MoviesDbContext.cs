using MoviesDatabase.Models;
using System.Data.Entity;

namespace MoviesDatabase.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext()
            : base("MoviesDBConnection")
        {

        }

        public DbSet<Movie> Movies;

        public DbSet<Star> Stars;

        public DbSet<Producer> Producers;

        public DbSet<Genre> Genres;

        public DbSet<Studio> Studios;

        public DbSet<Book> Books;
    }
}
