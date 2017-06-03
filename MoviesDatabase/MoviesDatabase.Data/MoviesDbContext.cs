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

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Star> Stars { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Studio> Studios { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
