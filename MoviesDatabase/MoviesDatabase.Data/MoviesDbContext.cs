using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using MoviesDatabase.Models;

namespace MoviesDatabase.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext()
            : base("MoviesHostedDB")
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Star> Stars { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Studio> Studios { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(
            DbModelBuilder modelBuilder)
        {
            this.OnBookModelCreating(modelBuilder);
            this.OnGenreModelCreating(modelBuilder);
            this.OnMovieModelCreating(modelBuilder);
            this.OnProducerModelCreating(modelBuilder);
            this.OnStarModelCreating(modelBuilder);
            this.OnStudioModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void OnBookModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(book => book.Title)
                .HasMaxLength(40)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_BookTitle") { IsUnique = true }));

            modelBuilder.Entity<Book>()
            .Property(book => book.Author)
            .HasMaxLength(50);
        }

        private void OnGenreModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .Property(genre => genre.Name)
                .HasMaxLength(20)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Genre") { IsUnique = true }));
        }

        private void OnMovieModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(movie => movie.Title)
                .HasMaxLength(50)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_MovieTitle") { IsUnique = true }));

            modelBuilder.Entity<Movie>()
                .Property(movie => movie.Description)
                .HasColumnType("ntext");

            modelBuilder.Entity<Movie>()
                .Property(movie => movie.BookID)
                .IsOptional();
        }

        private void OnProducerModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producer>()
                .Property(producer => producer.Name)
                .HasMaxLength(50)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_ProducerName") { IsUnique = true }));
        }

        private void OnStarModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Star>()
                .Property(star => star.FirstName)
                .HasMaxLength(15)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_FirstNameLastName", 1) { IsUnique = true }));

            modelBuilder.Entity<Star>()
                .Property(star => star.LastName)
                .HasMaxLength(15)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_FirstNameLastName", 2) { IsUnique = true }));

            modelBuilder.Entity<Star>()
                .Property(star => star.Address)
                .HasMaxLength(60);
        }

        private void OnStudioModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Studio>()
                .Property(studio => studio.Name)
                .HasMaxLength(30)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_StudioName") { IsUnique = true }));

            modelBuilder.Entity<Studio>()
                .Property(studio => studio.Address)
                .HasMaxLength(60);
        }
    }
}
